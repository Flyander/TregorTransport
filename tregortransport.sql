-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  mar. 10 déc. 2019 à 07:57
-- Version du serveur :  10.4.10-MariaDB
-- Version de PHP :  7.3.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `tregortransport`
--

-- --------------------------------------------------------

--
-- Structure de la table `arret`
--

DROP TABLE IF EXISTS `arret`;
CREATE TABLE IF NOT EXISTS `arret` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `position` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `nom` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `arret_ligne`
--

DROP TABLE IF EXISTS `arret_ligne`;
CREATE TABLE IF NOT EXISTS `arret_ligne` (
  `arret_id` int(11) NOT NULL,
  `ligne_id` int(11) NOT NULL,
  PRIMARY KEY (`arret_id`,`ligne_id`),
  KEY `IDX_3A128AB968F1C150` (`arret_id`),
  KEY `IDX_3A128AB95A438E76` (`ligne_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `bus`
--

DROP TABLE IF EXISTS `bus`;
CREATE TABLE IF NOT EXISTS `bus` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nb_place` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `chauffeur`
--

DROP TABLE IF EXISTS `chauffeur`;
CREATE TABLE IF NOT EXISTS `chauffeur` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `le_chauffeur_id` int(11) DEFAULT NULL,
  `nom` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `prenom` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `statut` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `adresse` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `telephone_c` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IDX_5CA777B88899931` (`le_chauffeur_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `date`
--

DROP TABLE IF EXISTS `date`;
CREATE TABLE IF NOT EXISTS `date` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `entreprise`
--

DROP TABLE IF EXISTS `entreprise`;
CREATE TABLE IF NOT EXISTS `entreprise` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `code_siret` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `forfait`
--

DROP TABLE IF EXISTS `forfait`;
CREATE TABLE IF NOT EXISTS `forfait` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `label` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `quantite_ticket` int(11) NOT NULL,
  `prix_forfait` int(11) NOT NULL,
  `le_forfait_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `IDX_BBB5C482B36D2087` (`le_forfait_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `ligne`
--

DROP TABLE IF EXISTS `ligne`;
CREATE TABLE IF NOT EXISTS `ligne` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `les_lignes_id` int(11) DEFAULT NULL,
  `nom` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IDX_57F0DB83BC57E904` (`les_lignes_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `migration_versions`
--

DROP TABLE IF EXISTS `migration_versions`;
CREATE TABLE IF NOT EXISTS `migration_versions` (
  `version` varchar(14) COLLATE utf8mb4_unicode_ci NOT NULL,
  `executed_at` datetime NOT NULL COMMENT '(DC2Type:datetime_immutable)',
  PRIMARY KEY (`version`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `migration_versions`
--

INSERT INTO `migration_versions` (`version`, `executed_at`) VALUES
('20191105134541', '2019-12-09 15:43:12'),
('20191203152943', '2019-12-03 15:29:56'),
('20191204133015', '2019-12-04 13:30:34'),
('20191205101438', '2019-12-05 10:15:08'),
('20191209102709', '2019-12-09 10:27:22'),
('20191210072109', '2019-12-10 07:21:37'),
('20191210072920', '2019-12-10 07:29:29'),
('20191210074421', '2019-12-10 07:44:36'),
('20191210075156', '2019-12-10 07:52:16');

-- --------------------------------------------------------

--
-- Structure de la table `mode_payement`
--

DROP TABLE IF EXISTS `mode_payement`;
CREATE TABLE IF NOT EXISTS `mode_payement` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `libelle` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `p`
--

DROP TABLE IF EXISTS `p`;
CREATE TABLE IF NOT EXISTS `p` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `payement`
--

DROP TABLE IF EXISTS `payement`;
CREATE TABLE IF NOT EXISTS `payement` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `les_utilisateurs_id` int(11) DEFAULT NULL,
  `date_payement` datetime NOT NULL,
  `les_modes_payements_id` int(11) DEFAULT NULL,
  `le_forfait_id` int(11) DEFAULT NULL,
  `mode_payement_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `IDX_B20A7885F5DBBA08` (`les_utilisateurs_id`),
  KEY `IDX_B20A7885FC6A6FCC` (`les_modes_payements_id`),
  KEY `IDX_B20A7885B36D2087` (`le_forfait_id`),
  KEY `IDX_B20A7885EF4F1912` (`mode_payement_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `user`
--

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(180) COLLATE utf8mb4_unicode_ci NOT NULL,
  `roles` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL CHECK (json_valid(`roles`)),
  `password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `nom` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `prenom` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `adresse` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `quantite_ticket_restant` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UNIQ_8D93D649E7927C74` (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `user_ligne`
--

DROP TABLE IF EXISTS `user_ligne`;
CREATE TABLE IF NOT EXISTS `user_ligne` (
  `user_id` int(11) NOT NULL,
  `ligne_id` int(11) NOT NULL,
  PRIMARY KEY (`user_id`,`ligne_id`),
  KEY `IDX_B53220DBA76ED395` (`user_id`),
  KEY `IDX_B53220DB5A438E76` (`ligne_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `utilisation`
--

DROP TABLE IF EXISTS `utilisation`;
CREATE TABLE IF NOT EXISTS `utilisation` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `l_utilisation_id` int(11) DEFAULT NULL,
  `chauffeur_id` int(11) DEFAULT NULL,
  `la_date_id` int(11) DEFAULT NULL,
  `le_bus_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `IDX_B02A3C43C5A70D42` (`l_utilisation_id`),
  KEY `IDX_B02A3C4385C0B3BE` (`chauffeur_id`),
  KEY `IDX_B02A3C43CAB41110` (`la_date_id`),
  KEY `IDX_B02A3C43854C8321` (`le_bus_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `arret_ligne`
--
ALTER TABLE `arret_ligne`
  ADD CONSTRAINT `FK_3A128AB95A438E76` FOREIGN KEY (`ligne_id`) REFERENCES `ligne` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_3A128AB968F1C150` FOREIGN KEY (`arret_id`) REFERENCES `arret` (`id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `chauffeur`
--
ALTER TABLE `chauffeur`
  ADD CONSTRAINT `FK_5CA777B88899931` FOREIGN KEY (`le_chauffeur_id`) REFERENCES `entreprise` (`id`);

--
-- Contraintes pour la table `forfait`
--
ALTER TABLE `forfait`
  ADD CONSTRAINT `FK_BBB5C482B36D2087` FOREIGN KEY (`le_forfait_id`) REFERENCES `entreprise` (`id`);

--
-- Contraintes pour la table `ligne`
--
ALTER TABLE `ligne`
  ADD CONSTRAINT `FK_57F0DB83BC57E904` FOREIGN KEY (`les_lignes_id`) REFERENCES `entreprise` (`id`);

--
-- Contraintes pour la table `payement`
--
ALTER TABLE `payement`
  ADD CONSTRAINT `FK_B20A7885B36D2087` FOREIGN KEY (`le_forfait_id`) REFERENCES `forfait` (`id`),
  ADD CONSTRAINT `FK_B20A7885F5DBBA08` FOREIGN KEY (`les_utilisateurs_id`) REFERENCES `user` (`id`);

--
-- Contraintes pour la table `user_ligne`
--
ALTER TABLE `user_ligne`
  ADD CONSTRAINT `FK_B53220DB5A438E76` FOREIGN KEY (`ligne_id`) REFERENCES `ligne` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_B53220DBA76ED395` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `utilisation`
--
ALTER TABLE `utilisation`
  ADD CONSTRAINT `FK_B02A3C43854C8321` FOREIGN KEY (`le_bus_id`) REFERENCES `bus` (`id`),
  ADD CONSTRAINT `FK_B02A3C4385C0B3BE` FOREIGN KEY (`chauffeur_id`) REFERENCES `chauffeur` (`id`),
  ADD CONSTRAINT `FK_B02A3C43C5A70D42` FOREIGN KEY (`l_utilisation_id`) REFERENCES `ligne` (`id`),
  ADD CONSTRAINT `FK_B02A3C43CAB41110` FOREIGN KEY (`la_date_id`) REFERENCES `date` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
