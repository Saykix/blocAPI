-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : lun. 06 mars 2023 à 02:57
-- Version du serveur : 10.4.22-MariaDB
-- Version de PHP : 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `bloc`
--

-- --------------------------------------------------------

--
-- Structure de la table `employer`
--

CREATE TABLE `employer` (
  `IdEmployer` int(11) NOT NULL,
  `nom` varchar(255) NOT NULL,
  `prenom` varchar(255) NOT NULL,
  `fixe` varchar(255) NOT NULL,
  `portable` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `employerService` int(11) NOT NULL,
  `employerSite` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `employer`
--

INSERT INTO `employer` (`IdEmployer`, `nom`, `prenom`, `fixe`, `portable`, `email`, `employerService`, `employerSite`) VALUES
(1, 'Martin', 'Sophie', '0456789123', '0678901234', 'sophie.martin@gmail.com', 2, 4),
(3, 'Lansonneur', 'David', '0567890123', '0698765432', 'david.lansonneur@gmail.com', 1, 1),
(4, 'Bernard', 'Camille', '0789456123', '0600123456', 'camille.bernard@gmail.com', 1, 4),
(5, 'Thomas', 'Hugo', '0123456789', '0678901234', 'hugo.thomas@gmail.com', 2, 1),
(6, 'Leroy', 'Sarah', '0456789123', '0687654321', 'sarah.leroy@gmail.com', 3, 5),
(7, 'Rousseau', 'Paul', '0234567890', '0612345678', 'paul.rousseau@gmail.com', 4, 2),
(8, 'Lefebvre', 'Emma', '0678901234', '0698765432', 'emma.lefebvre@gmail.com', 5, 3),
(9, 'Michel', 'Lucie', '0567890123', '0600123456', 'lucie.michel@gmail.com', 1, 2),
(10, 'Garcia', 'Julien', '0789456123', '0678901234', 'julien.garcia@gmail.com', 2, 5),
(11, 'Rodriguez', 'Chloé', '0123456789', '0687654321', 'chloe.rodriguez@gmail.com', 3, 4),
(12, 'Morin', 'Antoine', '0456789123', '0612345678', 'antoine.morin@gmail.com', 4, 1),
(13, 'Lecomte', 'Lecomte', '0234567890', '0698765432', 'manon.lecomte@gmail.com', 5, 2),
(14, 'Dubois', 'Jérôme', '0678901234', '0600123456', 'jerome.dubois@gmail.com', 1, 5),
(15, 'Laurent', 'Sophie', '0567890123', '0678901234', 'sophie.laurent@gmail.com', 2, 4),
(16, 'Morel', 'Rémi', '0789456123', '0687654321', 'remi.morel@gmail.com', 3, 3);

-- --------------------------------------------------------

--
-- Structure de la table `service`
--

CREATE TABLE `service` (
  `IdService` int(11) NOT NULL,
  `nomService` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `service`
--

INSERT INTO `service` (`IdService`, `nomService`) VALUES
(1, 'Comptabilité'),
(2, 'Production'),
(3, 'Accueil'),
(4, 'Informatique'),
(5, 'Commercial');

-- --------------------------------------------------------

--
-- Structure de la table `site`
--

CREATE TABLE `site` (
  `IdSite` int(11) NOT NULL,
  `ville` varchar(255) NOT NULL,
  `adresse` varchar(255) NOT NULL,
  `codePostal` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `site`
--

INSERT INTO `site` (`IdSite`, `ville`, `adresse`, `codePostal`) VALUES
(1, 'Paris', '3 Rue Abel Ferry', '70123'),
(2, 'Nates', '8 rue Mazagran', '44000'),
(3, 'Toulouse', '5 rue Ferdinand Laulanie', '31000'),
(4, 'Nice', '11 boulevard Pierre Semard', '06000'),
(5, 'Lille', '47 rue du Faubourg de Roubaix', '59777');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `employer`
--
ALTER TABLE `employer`
  ADD PRIMARY KEY (`IdEmployer`),
  ADD KEY `employerService` (`employerService`),
  ADD KEY `employerSite` (`employerSite`);

--
-- Index pour la table `service`
--
ALTER TABLE `service`
  ADD PRIMARY KEY (`IdService`);

--
-- Index pour la table `site`
--
ALTER TABLE `site`
  ADD PRIMARY KEY (`IdSite`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `employer`
--
ALTER TABLE `employer`
  MODIFY `IdEmployer` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT pour la table `service`
--
ALTER TABLE `service`
  MODIFY `IdService` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT pour la table `site`
--
ALTER TABLE `site`
  MODIFY `IdSite` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `employer`
--
ALTER TABLE `employer`
  ADD CONSTRAINT `employer_ibfk_1` FOREIGN KEY (`employerService`) REFERENCES `service` (`IdService`),
  ADD CONSTRAINT `employer_ibfk_2` FOREIGN KEY (`employerSite`) REFERENCES `site` (`IdSite`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
