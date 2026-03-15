CREATE DATABASE  IF NOT EXISTS `emprestimosbd` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `emprestimosbd`;
-- MySQL dump 10.13  Distrib 8.0.44, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: emprestimosbd
-- ------------------------------------------------------
-- Server version	5.7.43-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `nome_cliente` varchar(120) NOT NULL,
  `nome_fantasia` varchar(150) DEFAULT NULL,
  `cpf_cnpj` varchar(18) NOT NULL,
  `tipo_ie` varchar(50) DEFAULT NULL,
  `inscricao_estadual` varchar(20) DEFAULT NULL,
  `genero` enum('Masculino','Feminino','Outros') DEFAULT 'Outros',
  `estado_civil` varchar(50) DEFAULT NULL,
  `endereco` varchar(150) NOT NULL,
  `bairro` varchar(100) NOT NULL,
  `cidade` varchar(100) NOT NULL,
  `uf` char(10) NOT NULL,
  `numero_residencia` varchar(20) NOT NULL,
  `cep` varchar(10) DEFAULT NULL,
  `celular` varchar(20) DEFAULT NULL,
  `email` varchar(120) DEFAULT NULL,
  `observacoes` text,
  `situacao_cadastral` varchar(20) DEFAULT NULL,
  `imagem` longblob,
  `data_cadastro` date DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `conta_receber`
--

DROP TABLE IF EXISTS `conta_receber`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `conta_receber` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `codigo_emprestimo` int(11) NOT NULL,
  `codigo_cliente` int(11) NOT NULL,
  `numero_parcela` int(11) NOT NULL,
  `valor_parcela` decimal(10,2) NOT NULL,
  `percentual_parcela` decimal(10,2) NOT NULL,
  `valor_pago` decimal(10,2) DEFAULT '0.00',
  `data_pagamento` datetime DEFAULT NULL,
  `data_ultimo_pagamento` datetime DEFAULT NULL,
  `data_ultimo_calculo_juros` date DEFAULT NULL,
  `data_vencimento` date DEFAULT NULL,
  `status_parcela` enum('ABERTA','PAGA','ATRASADA') DEFAULT 'ABERTA',
  `observacoes` text,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `codigo_emprestimo` (`codigo_emprestimo`,`numero_parcela`),
  KEY `fk_codigo_cliente` (`codigo_cliente`),
  CONSTRAINT `fk_codigo_cliente` FOREIGN KEY (`codigo_cliente`) REFERENCES `cliente` (`codigo`),
  CONSTRAINT `fk_codigo_emprestimo` FOREIGN KEY (`codigo_emprestimo`) REFERENCES `emprestimos` (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `conta_receber`
--

LOCK TABLES `conta_receber` WRITE;
/*!40000 ALTER TABLE `conta_receber` DISABLE KEYS */;
/*!40000 ALTER TABLE `conta_receber` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `emprestimos`
--

DROP TABLE IF EXISTS `emprestimos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `emprestimos` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `codigo_cliente` int(11) NOT NULL,
  `valor_emprestado` decimal(10,2) NOT NULL,
  `valor_emprestado_total` decimal(10,2) DEFAULT NULL,
  `quantidade_parcela` int(11) DEFAULT NULL,
  `valor_parcela` decimal(10,2) DEFAULT NULL,
  `valor_juros` decimal(10,2) DEFAULT NULL,
  `percentual_juros` decimal(10,2) DEFAULT NULL,
  `tipo_juros` enum('MENSAL','DIARIO') NOT NULL DEFAULT 'MENSAL',
  `data_emprestimo` date NOT NULL,
  `data_pagar` date DEFAULT NULL,
  `data_quitacao` datetime DEFAULT NULL,
  `observacoes` text,
  `status_emprestimo` enum('ATIVO','QUITADO','ATRASADO') DEFAULT 'ATIVO',
  PRIMARY KEY (`codigo`),
  KEY `idx_codigo_cliente` (`codigo_cliente`),
  CONSTRAINT `fk_emprestimos_cliente` FOREIGN KEY (`codigo_cliente`) REFERENCES `cliente` (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `emprestimos`
--

LOCK TABLES `emprestimos` WRITE;
/*!40000 ALTER TABLE `emprestimos` DISABLE KEYS */;
/*!40000 ALTER TABLE `emprestimos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estorno_pagamento`
--

DROP TABLE IF EXISTS `estorno_pagamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `estorno_pagamento` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `codigo_parcela` int(11) NOT NULL,
  `codigo_emprestimo` int(11) NOT NULL,
  `codigo_funcionario` int(11) NOT NULL,
  `data_estorno` datetime DEFAULT CURRENT_TIMESTAMP,
  `valor_estornado` decimal(10,2) NOT NULL,
  `motivo_estorno` text NOT NULL,
  PRIMARY KEY (`codigo`),
  KEY `codigo_parcela` (`codigo_parcela`),
  KEY `codigo_funcionario` (`codigo_funcionario`),
  KEY `codigo_emprestimo` (`codigo_emprestimo`),
  CONSTRAINT `estorno_pagamento_ibfk_1` FOREIGN KEY (`codigo_parcela`) REFERENCES `conta_receber` (`codigo`),
  CONSTRAINT `estorno_pagamento_ibfk_2` FOREIGN KEY (`codigo_funcionario`) REFERENCES `funcionario` (`codigo`),
  CONSTRAINT `estorno_pagamento_ibfk_3` FOREIGN KEY (`codigo_emprestimo`) REFERENCES `emprestimos` (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estorno_pagamento`
--

LOCK TABLES `estorno_pagamento` WRITE;
/*!40000 ALTER TABLE `estorno_pagamento` DISABLE KEYS */;
/*!40000 ALTER TABLE `estorno_pagamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `funcionario`
--

DROP TABLE IF EXISTS `funcionario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `funcionario` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `nome_funcionario` varchar(100) NOT NULL,
  `cpf_funcionario` varchar(20) NOT NULL,
  `sexo_funcionario` varchar(30) NOT NULL,
  `funcionario_estado_civil` varchar(30) NOT NULL,
  `username` varchar(50) NOT NULL,
  `senha_hash` varchar(255) NOT NULL,
  `telefone_funcionario` varchar(30) NOT NULL,
  `cidade_funcionario` varchar(100) NOT NULL,
  `endereco_funcionario` varchar(150) DEFAULT NULL,
  `bairro_funcionario` varchar(100) DEFAULT NULL,
  `numero_residencia` varchar(10) DEFAULT NULL,
  `cep_funcionario` varchar(9) DEFAULT NULL,
  `uf_funcionario` char(2) DEFAULT NULL,
  `situacao_funcionario` varchar(20) NOT NULL,
  `data_cadastro` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `cpf_funcionario` (`cpf_funcionario`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `funcionario`
--

LOCK TABLES `funcionario` WRITE;
/*!40000 ALTER TABLE `funcionario` DISABLE KEYS */;
INSERT INTO `funcionario` VALUES (1,'Empréstimos Sistemas LTDA','00097824607','Masculino','Solteiro(a)','EMPRESTIMOS SISTEMAS','$2a$11$cAsgIy6emCdC3k82GhuAH.bKqUJId/vsEEOKfp8Lo4C1LNBRN1.Au','00000000000','Montes Claros','Rua Cristiano do \'O\'','Vila Guilhermina','272','39400465','MG','ATIVO','2026-03-15 15:07:04');
/*!40000 ALTER TABLE `funcionario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `funcionario_tela_privilegio`
--

DROP TABLE IF EXISTS `funcionario_tela_privilegio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `funcionario_tela_privilegio` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `codigo_funcionario` int(11) DEFAULT NULL,
  `codigo_tela` int(11) DEFAULT NULL,
  `pode_acessar` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `codigo_funcionario` (`codigo_funcionario`),
  KEY `codigo_tela` (`codigo_tela`),
  CONSTRAINT `funcionario_tela_privilegio_ibfk_1` FOREIGN KEY (`codigo_funcionario`) REFERENCES `funcionario` (`codigo`),
  CONSTRAINT `funcionario_tela_privilegio_ibfk_2` FOREIGN KEY (`codigo_tela`) REFERENCES `telas_sistema` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `funcionario_tela_privilegio`
--

LOCK TABLES `funcionario_tela_privilegio` WRITE;
/*!40000 ALTER TABLE `funcionario_tela_privilegio` DISABLE KEYS */;
INSERT INTO `funcionario_tela_privilegio` VALUES (1,1,1,1),(2,1,2,1),(3,1,3,1),(4,1,4,1),(5,1,5,1),(6,1,6,1),(7,1,7,1),(8,1,9,1),(9,1,10,1),(10,1,8,1);
/*!40000 ALTER TABLE `funcionario_tela_privilegio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lembrete`
--

DROP TABLE IF EXISTS `lembrete`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lembrete` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `codigo_funcionario` int(11) NOT NULL,
  `titulo` varchar(150) NOT NULL,
  `descricao` text,
  `situacao` enum('ATIVO','EXCLUIDO') DEFAULT 'ATIVO',
  PRIMARY KEY (`codigo`),
  KEY `fk_codigo_funcionario` (`codigo_funcionario`),
  CONSTRAINT `fk_codigo_funcionario` FOREIGN KEY (`codigo_funcionario`) REFERENCES `funcionario` (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lembrete`
--

LOCK TABLES `lembrete` WRITE;
/*!40000 ALTER TABLE `lembrete` DISABLE KEYS */;
/*!40000 ALTER TABLE `lembrete` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `modelo_mensagem`
--

DROP TABLE IF EXISTS `modelo_mensagem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `modelo_mensagem` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(100) NOT NULL,
  `mensagem` text NOT NULL,
  `situacao` enum('ATIVO','INATIVO') DEFAULT 'ATIVO',
  `data_cadastro` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modelo_mensagem`
--

LOCK TABLES `modelo_mensagem` WRITE;
/*!40000 ALTER TABLE `modelo_mensagem` DISABLE KEYS */;
/*!40000 ALTER TABLE `modelo_mensagem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `telas_sistema`
--

DROP TABLE IF EXISTS `telas_sistema`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `telas_sistema` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `nome_tela` varchar(100) DEFAULT NULL,
  `form_name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `telas_sistema`
--

LOCK TABLES `telas_sistema` WRITE;
/*!40000 ALTER TABLE `telas_sistema` DISABLE KEYS */;
INSERT INTO `telas_sistema` VALUES (1,'Cadastro Cliente','frmCadastroCliente'),(2,'Cadastro Funcionario','frmCadastroFuncionario'),(3,'Consultar Parcela','frmConsultarParcelas'),(4,'Novos Emprestimos','frmNovosEmprestimos'),(5,'Pagamento Emprestimos','frmPagamentoEmprestimo'),(6,'Visualizar Emprestimos','frmVisualizarEmprestimos'),(7,'Cadastro - Mensagem (WhatsApp)','frmCadastroMensagemCobranca'),(8,'Cobrança','frmCobrancaWhatsApp'),(9,'Cadastro de Pessoa Jurídica','frmCadastroClientePJ'),(10,'Estorno de Recebimento de Empréstimos','frmEstornarPagamento');
/*!40000 ALTER TABLE `telas_sistema` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-03-15 15:34:34
