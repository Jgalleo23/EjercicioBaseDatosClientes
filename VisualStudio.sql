-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         5.5.40 - MySQL Community Server (GPL)
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.6.0.6765
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para clientes
DROP DATABASE IF EXISTS `clientes`;
CREATE DATABASE IF NOT EXISTS `clientes` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `clientes`;

-- Volcando estructura para tabla clientes.lineas
DROP TABLE IF EXISTS `lineas`;
CREATE TABLE IF NOT EXISTS `lineas` (
  `COD_PRESUPUESTO` int(11) DEFAULT NULL,
  `COD_ARTICULO` int(11) DEFAULT NULL,
  `DESCRIPCION` varchar(50) DEFAULT NULL,
  `CANTIDAD` int(11) DEFAULT NULL,
  `PRECIO` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla clientes.lineas: ~8 rows (aproximadamente)
DELETE FROM `lineas`;
INSERT INTO `lineas` (`COD_PRESUPUESTO`, `COD_ARTICULO`, `DESCRIPCION`, `CANTIDAD`, `PRECIO`) VALUES
	(1, 1, '1', 1, 1),
	(2, 2, '2', 2, 2),
	(3, 3, '3', 3, 3),
	(4, 4, '4', 4, 4),
	(6, 6, '6', 6, 6),
	(7, 7, '7', 7, 7),
	(888, 88888, '88888', 8, 8),
	(9, 9, 'Mamaluca', 2, 9);

-- Volcando estructura para tabla clientes.presupuestos
DROP TABLE IF EXISTS `presupuestos`;
CREATE TABLE IF NOT EXISTS `presupuestos` (
  `COD` int(11) DEFAULT NULL,
  `FECHA` date DEFAULT NULL,
  `TOTAL` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla clientes.presupuestos: ~6 rows (aproximadamente)
DELETE FROM `presupuestos`;
INSERT INTO `presupuestos` (`COD`, `FECHA`, `TOTAL`) VALUES
	(3, '2023-12-12', 9),
	(4, '2023-12-12', 16),
	(6, '2023-12-12', 36),
	(7, '2023-12-12', 49),
	(888, '2023-12-12', 64),
	(9, '2023-12-12', 18);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
