-- phpMyAdmin SQL Dump
-- version 4.0.4
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Oct 15, 2013 at 07:29 PM
-- Server version: 5.6.12-log
-- PHP Version: 5.4.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `mypizarron`
--
CREATE DATABASE IF NOT EXISTS `myplumon` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `myplumon`;

-- --------------------------------------------------------

--
-- Table structure for table `cursos`
--

CREATE TABLE IF NOT EXISTS `cursos` (
  `id_curso` varchar(255) NOT NULL,
  `nombre` text NOT NULL,
  `estado` int(1) NOT NULL,
  `imagen_curso` text,
  `id_docente` varchar(255) NOT NULL,
  `id_periodos` varchar(255) NOT NULL,
  `fecha_inicio` date NOT NULL,
  `id_noticias` varchar(255) DEFAULT NULL,
  `id_comentarios` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_curso`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cursos`
--

INSERT INTO `cursos` (`id_curso`, `nombre`, `estado`, `imagen_curso`, `id_docente`, `id_periodos`, `fecha_inicio`, `id_noticias`, `id_comentarios`) VALUES
('curso_asp_500', 'ASP.NET', 1, 'curso1.jpg', 'pumVwazCGFwB9KytZkhzpcgc2S1p1T7Oy5lVR0soR3o=', 'periodo__', '2013-09-19', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `documentos_cursos`
--

CREATE TABLE IF NOT EXISTS `documentos_cursos` (
  `id_documentos` varchar(255) NOT NULL,
  `id_curso` varchar(255) NOT NULL,
  `id_periodo` varchar(255) NOT NULL,
  `nombre` text NOT NULL,
  `titulo` text NOT NULL,
  `archivo` text NOT NULL,
  PRIMARY KEY (`id_documentos`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `estudiante_curso`
--

CREATE TABLE IF NOT EXISTS `estudiante_curso` (
  `id_estudiante` varchar(255) NOT NULL,
  `id_curso` varchar(255) NOT NULL,
  `id_user` text NOT NULL,
  PRIMARY KEY (`id_curso`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `foros_curso`
--

CREATE TABLE IF NOT EXISTS `foros_curso` (
  `id_foro` varchar(255) NOT NULL,
  `id_user` varchar(255) NOT NULL,
  `id_curso` varchar(255) NOT NULL,
  `nombre` text NOT NULL,
  `descripcion` text NOT NULL,
  `id_estudiantes` varchar(255) NOT NULL,
  `id_comentario` varchar(255) NOT NULL,
  `estado` int(1) NOT NULL,
  PRIMARY KEY (`id_foro`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `log`
--

CREATE TABLE IF NOT EXISTS `log` (
  `id_log` varchar(255) NOT NULL,
  `id_user` varchar(255) NOT NULL,
  `user` text NOT NULL,
  `password` text NOT NULL,
  `estado` int(11) NOT NULL,
  PRIMARY KEY (`id_log`),
  UNIQUE KEY `id_log` (`id_log`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `log`
--

INSERT INTO `log` (`id_log`, `id_user`, `user`, `password`, `estado`) VALUES
('CVSJ2d/tHD3K50dCYo0+s1k16LEEAJLK4Mz5gvvXuwA=', 'i4z80scbT4BUL9oKHLJ9S/6UTdxr1ltlDGJfXFNeoSs=', 'mario.duran', 'mario', 1),
('Kw/TVyz+ChjxRmnhBJIRfJmxQVZ6zEXls4iNwbuvTfI=', '0UYc8Xk62+w4kEHO0Amzb4TXyDUCzMNHkGekPNbg75k=', 'calin92', 'calin', 1),
('Uz9EI0EFURQ9P0qX2s/KmGJoLQal6bELJ23nlBEgZM0=', '6M5Z2SjMEZMhnQOg0wcdpP/AAh++/9bvEvGUz3G3RJk=', 'mario90', 'linux', 1),
('WBMFT1k6lqdxaccdgnoaeh4L/UgDxIBX6c4lRLKFaCo=', 'Rc5LluKVZCFVIkezkcCBOSKXbs8Pym1waN6tN4HiaSY=', 'albert', 'linux', 1),
('WG1qopTZ+jPhF8u3ySrJSfjqNJRvr7e+l3OkiAbf9Xg=', 'pumVwazCGFwB9KytZkhzpcgc2S1p1T7Oy5lVR0soR3o=', 'rolignu', 'linux', 1),
('zY8qk9QVQNdfLvLH7qoQNl4qKE1JjqZa4S7obKblEKQ=', 'QfNmXIg+KDIhxILQazJMzmEBRIoB6kNL94mWeHcQRI0=', 'petersito', 'peter', 1);

-- --------------------------------------------------------

--
-- Table structure for table `log_`
--

CREATE TABLE IF NOT EXISTS `log_` (
  `id_log_` int(11) NOT NULL AUTO_INCREMENT,
  `id_user` varchar(255) DEFAULT NULL,
  `error` text NOT NULL,
  `sector` text NOT NULL,
  `fecha` date NOT NULL,
  PRIMARY KEY (`id_log_`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `log_`
--

INSERT INTO `log_` (`id_log_`, `id_user`, `error`, `sector`, `fecha`) VALUES
(1, 'NULL', 'prueba de log', 'Login inicio de sesion', '2013-09-19'),
(2, 'NULL', 'El buzón de correo no está disponible. La respuesta del servidor fue: 5.7.3 Requested action aborted; user not authenticated', 'Recuperar contraseña', '2013-09-28'),
(3, 'NULL', 'El buzón de correo no está disponible. La respuesta del servidor fue: 5.7.3 Requested action aborted; user not authenticated', 'Recuperar contraseña', '2013-09-28'),
(4, 'NULL', 'Error sesion', 'curso', '2013-10-05'),
(5, 'NULL', 'La cadena especificada no tiene la forma obligatoria para una dirección de correo electrónico.', 'Recuperar contraseña', '2013-10-10'),
(6, 'NULL', 'Referencia a objeto no establecida como instancia de un objeto.', 'Seguridad correo verificar', '2013-10-12'),
(7, 'pumVwazCGFwB9KytZkhzpcgc2S1p1T7Oy5lVR0soR3o=', 'Índice fuera de los límites de la matriz.', 'editar perfil', '2013-10-14');

-- --------------------------------------------------------

--
-- Table structure for table `mensajeria`
--

CREATE TABLE IF NOT EXISTS `mensajeria` (
  `id_mensaje` int(11) NOT NULL AUTO_INCREMENT,
  `id_user` varchar(255) DEFAULT NULL,
  `id_usuario_de` varchar(255) NOT NULL,
  `mensaje` text NOT NULL,
  `fecha` date NOT NULL,
  `hora` text NOT NULL,
  `leido` int(1) NOT NULL,
  PRIMARY KEY (`id_mensaje`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COMMENT='sistema que maneja la mensajeria de los modulos' AUTO_INCREMENT=4 ;

--
-- Dumping data for table `mensajeria`
--

INSERT INTO `mensajeria` (`id_mensaje`, `id_user`, `id_usuario_de`, `mensaje`, `fecha`, `hora`, `leido`) VALUES
(1, 'pumVwazCGFwB9KytZkhzpcgc2S1p1T7Oy5lVR0soR3o=', 'pumVwazCGFwB9KytZkhzpcgc2S1p1T7Oy5lVR0soR3o=', 'hola como estas ', '2013-10-01', '12:50', 0),
(2, 'pumVwazCGFwB9KytZkhzpcgc2S1p1T7Oy5lVR0soR3o=', 'pumVwazCGFwB9KytZkhzpcgc2S1p1T7Oy5lVR0soR3o=', 'HOLA COMO ESTAS MARICA', '2013-10-01', '12:50', 0),
(3, 'pumVwazCGFwB9KytZkhzpcgc2S1p1T7Oy5lVR0soR3o=', 'pumVwazCGFwB9KytZkhzpcgc2S1p1T7Oy5lVR0soR3o=', 'HOLA COMO ESTAS MARICA', '2013-10-01', '12:50', 0);

-- --------------------------------------------------------

--
-- Table structure for table `periodo_curso`
--

CREATE TABLE IF NOT EXISTS `periodo_curso` (
  `id_periodo` varchar(255) NOT NULL,
  `id_curso` varchar(255) NOT NULL,
  `nombre` text NOT NULL,
  `estado` int(11) NOT NULL,
  PRIMARY KEY (`id_periodo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `periodo_curso`
--

INSERT INTO `periodo_curso` (`id_periodo`, `id_curso`, `nombre`, `estado`) VALUES
('AKDgl30h25iCTzKN6Gt9yBcP1PG6pQnfyUuqR5bpbI=', 'curso_asp_500', 'periodo 1 (interfaces)', 1),
('dJxLDhHg8JeMjev2O9Hz4i/mEU2s2Jr0YP2nJNRgUig=', 'curso_asp_500', 'periodo 2', 1),
('dXTgJaAfia4FZCVPSU0rXG0J0RUz5TimqJfwAM/MAlc=', 'curso_asp_500', 'periodo 3 ', 0);

-- --------------------------------------------------------

--
-- Table structure for table `periodo_documentos`
--

CREATE TABLE IF NOT EXISTS `periodo_documentos` (
  `id_p_documentos` int(11) NOT NULL AUTO_INCREMENT,
  `id_periodo` varchar(255) NOT NULL,
  `titulo` text,
  `notas` text,
  `fecha` date NOT NULL,
  `id_documento` varchar(255) DEFAULT NULL,
  `id_foro` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_p_documentos`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `repositorio_curso`
--

CREATE TABLE IF NOT EXISTS `repositorio_curso` (
  `id_repositorio` varchar(255) NOT NULL,
  `id_tarea` varchar(255) NOT NULL,
  `id_estudiante` varchar(255) NOT NULL,
  `archivo` text NOT NULL,
  `estado` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tarea_curso`
--

CREATE TABLE IF NOT EXISTS `tarea_curso` (
  `id_tarea` varchar(255) NOT NULL,
  `id_curso` varchar(255) NOT NULL,
  `id_repositorio` varchar(255) NOT NULL,
  `nombre` text NOT NULL,
  `fecha_inicio` date NOT NULL,
  `fecha_limite` date NOT NULL,
  `asignacion` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `id_user` varchar(255) NOT NULL,
  `nombre` text NOT NULL,
  `apellido` text,
  `alias` text,
  `email` text NOT NULL,
  `nacimiento` date NOT NULL,
  `facebook` text,
  `twitter` text,
  `institucion` varchar(100) NOT NULL,
  `sexo` varchar(20) NOT NULL,
  `pais` text NOT NULL,
  `perfil` int(1) NOT NULL,
  `imagen` text,
  `fecha_inicio` date NOT NULL,
  PRIMARY KEY (`id_user`),
  UNIQUE KEY `id_user` (`id_user`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`id_user`, `nombre`, `apellido`, `alias`, `email`, `nacimiento`, `facebook`, `twitter`, `institucion`, `sexo`, `pais`, `perfil`, `imagen`, `fecha_inicio`) VALUES
('0UYc8Xk62+w4kEHO0Amzb4TXyDUCzMNHkGekPNbg75k=', 'carlos', 'ernesto ', 'calin', 'carlos.carlos@gmail.com', '1973-06-18', '', 'rolignu', 'Colegio Don bosco', 'Masculino', 'El salvador', 0, '202350034_202350034202350034.jpeg', '2013-10-08'),
('6M5Z2SjMEZMhnQOg0wcdpP/AAh++/9bvEvGUz3G3RJk=', 'mario', 'duran', 'marito', 'mario.duran@gmail.com', '1979-07-07', '', 'Abrastamp ', 'Universidad Don bosco', 'Masculino', 'Honduras', 0, ' NULL', '2013-10-10'),
('i4z80scbT4BUL9oKHLJ9S/6UTdxr1ltlDGJfXFNeoSs=', 'mario', 'duran', 'alessa', 'mario.duran@gmail.com', '1990-08-19', '', '', 'Universidad Don bosco', 'Masculino', 'El salvador', 0, ' NULL', '2013-09-08'),
('pumVwazCGFwB9KytZkhzpcgc2S1p1T7Oy5lVR0soR3o=', 'Rolando Antonio', 'Arriaza Marroquin', 'Roli', 'rolignu90@gmail.com', '1990-06-18', 'https://www.facebook.com/rolando.a.arriaza', 'chalogandul', 'Universidad Don bosco', 'Masculino', 'El salvador', 1, '1909236732_19092367321909236732.jpg', '2013-09-06'),
('QfNmXIg+KDIhxILQazJMzmEBRIoB6kNL94mWeHcQRI0=', 'peter', 'jarquin', 'peter', 'peter.tumadre@hotmail.com', '1993-04-17', '', '', 'Universidad Centroamericana (UCA)', 'Masculino', 'El salvador', 0, '2135760787_21357607872135760787.jpeg', '2013-10-01'),
('Rc5LluKVZCFVIkezkcCBOSKXbs8Pym1waN6tN4HiaSY=', 'alberto', 'arriaza', 'albert', 'alber@gmail.com', '1959-03-18', 'https://www.facebook.com/josemauricio.floresaviles?fref=ts', 'rolignu', 'Universidad De El Salvador', 'Masculino', 'El salvador', 0, '1042392813_10423928131042392813.jpeg', '2013-09-16');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
