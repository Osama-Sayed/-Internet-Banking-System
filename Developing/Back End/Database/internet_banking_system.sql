-- phpMyAdmin SQL Dump
-- version 5.3.0-dev+20220508.7aa512c357
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 10, 2022 at 12:41 PM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `internet_banking_system`
--

-- --------------------------------------------------------

--
-- Table structure for table `accounts`
--

CREATE TABLE `accounts` (
  `AccountNumber` int(20) NOT NULL,
  `ClientID` int(10) NOT NULL,
  `AccountType` varchar(20) NOT NULL,
  `Balance` int(10) NOT NULL,
  `AdminUserName` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `accounts`
--

INSERT INTO `accounts` (`AccountNumber`, `ClientID`, `AccountType`, `Balance`, `AdminUserName`) VALUES
(1234, 1, 'saving', 123456, 'h1'),
(2020, 3, '23', 1456, 'h1'),
(123456789, 4, 'accountType', 203040, 'h1'),
(1233455667, 1, 'current', 10000, 'h1');

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `UserName` varchar(20) NOT NULL,
  `Password` char(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`UserName`, `Password`) VALUES
('h1', '1234');

-- --------------------------------------------------------

--
-- Table structure for table `client`
--

CREATE TABLE `client` (
  `ClientID` int(10) NOT NULL,
  `UserName` varchar(20) NOT NULL,
  `Email` varchar(50) NOT NULL,
  `Password` char(40) NOT NULL,
  `AdminUserName` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `client`
--

INSERT INTO `client` (`ClientID`, `UserName`, `Email`, `Password`, `AdminUserName`) VALUES
(1, 'aya', 'aya@gmail.com', '334445', 'h1'),
(3, 'sara', 'sara@gmail.com', '55555', 'h1'),
(4, 'saad', 'saad@gmail.com', '1234', 'h1');

-- --------------------------------------------------------

--
-- Table structure for table `client_phonenumber`
--

CREATE TABLE `client_phonenumber` (
  `ClientID` int(10) NOT NULL,
  `ID` int(10) NOT NULL,
  `PhoneNumber` char(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `client_phonenumber`
--

INSERT INTO `client_phonenumber` (`ClientID`, `ID`, `PhoneNumber`) VALUES
(3, 1, '222222'),
(3, 50, '011'),
(1, 65, '12'),
(1, 234, '11124'),
(1, 5252, '11');

-- --------------------------------------------------------

--
-- Table structure for table `transfer`
--

CREATE TABLE `transfer` (
  `TransferID` int(15) NOT NULL,
  `AccountNumber` int(20) NOT NULL,
  `Currency` varchar(10) NOT NULL,
  `Amount` int(15) NOT NULL,
  `DestinationAccountNumber` int(20) NOT NULL,
  `SourceAccountNumber` int(20) NOT NULL,
  `Date` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `transfer`
--

INSERT INTO `transfer` (`TransferID`, `AccountNumber`, `Currency`, `Amount`, `DestinationAccountNumber`, `SourceAccountNumber`, `Date`) VALUES
(123, 1233455667, '123', 77, 12, 123, '2022-05-09 15:39:03'),
(145, 2020, '256', 1237890, 7895, 8858, '2022-05-09 15:39:37'),
(5050, 1234, '2020', 1500, 15369745, 7896545, '2022-05-09 15:58:16');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `accounts`
--
ALTER TABLE `accounts`
  ADD PRIMARY KEY (`AccountNumber`),
  ADD KEY `UserID` (`ClientID`),
  ADD KEY `AdminUserName` (`AdminUserName`);

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`UserName`),
  ADD UNIQUE KEY `UserName` (`UserName`);

--
-- Indexes for table `client`
--
ALTER TABLE `client`
  ADD PRIMARY KEY (`ClientID`),
  ADD UNIQUE KEY `UserName` (`UserName`),
  ADD UNIQUE KEY `UserID` (`ClientID`),
  ADD KEY `AdminUserName` (`AdminUserName`);

--
-- Indexes for table `client_phonenumber`
--
ALTER TABLE `client_phonenumber`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `ID` (`ID`),
  ADD KEY `ClientID` (`ClientID`);

--
-- Indexes for table `transfer`
--
ALTER TABLE `transfer`
  ADD PRIMARY KEY (`TransferID`),
  ADD KEY `Account Number` (`AccountNumber`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `client`
--
ALTER TABLE `client`
  MODIFY `ClientID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `client_phonenumber`
--
ALTER TABLE `client_phonenumber`
  MODIFY `ID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5253;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `accounts`
--
ALTER TABLE `accounts`
  ADD CONSTRAINT `accounts_ibfk_1` FOREIGN KEY (`ClientID`) REFERENCES `client` (`ClientID`),
  ADD CONSTRAINT `accounts_ibfk_2` FOREIGN KEY (`AdminUserName`) REFERENCES `admin` (`UserName`);

--
-- Constraints for table `client`
--
ALTER TABLE `client`
  ADD CONSTRAINT `client_ibfk_1` FOREIGN KEY (`AdminUserName`) REFERENCES `admin` (`UserName`);

--
-- Constraints for table `client_phonenumber`
--
ALTER TABLE `client_phonenumber`
  ADD CONSTRAINT `client_phonenumber_ibfk_1` FOREIGN KEY (`ClientID`) REFERENCES `client` (`ClientID`);

--
-- Constraints for table `transfer`
--
ALTER TABLE `transfer`
  ADD CONSTRAINT `transfer_ibfk_1` FOREIGN KEY (`AccountNumber`) REFERENCES `accounts` (`AccountNumber`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;



