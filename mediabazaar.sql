-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 20, 2021 at 12:09 PM
-- Server version: 10.4.17-MariaDB
-- PHP Version: 8.0.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `mediabazaar`
--

-- --------------------------------------------------------

--
-- Table structure for table `accesslevel`
--

CREATE TABLE `accesslevel` (
  `ID` int(11) NOT NULL,
  `Name` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `accesslevel`
--

INSERT INTO `accesslevel` (`ID`, `Name`) VALUES
(2, 'Admin'),
(1, 'Employee'),
(3, 'Manager');

-- --------------------------------------------------------

--
-- Table structure for table `contract`
--

CREATE TABLE `contract` (
  `ID` int(11) NOT NULL,
  `Fixed` tinyint(1) NOT NULL,
  `Hours` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `contract`
--

INSERT INTO `contract` (`ID`, `Fixed`, `Hours`) VALUES
(1, 1, 40),
(2, 1, 32),
(3, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `department`
--

CREATE TABLE `department` (
  `ID` int(11) NOT NULL,
  `Name` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `department`
--

INSERT INTO `department` (`ID`, `Name`) VALUES
(3, 'Cashier'),
(2, 'Electronics'),
(1, 'Household'),
(4, 'Tools');

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `ID` int(11) NOT NULL,
  `BirthDate` datetime NOT NULL,
  `HireDate` datetime NOT NULL,
  `LastWorkingDay` datetime DEFAULT NULL,
  `Country` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `City` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Street` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `StreetNumber` int(11) NOT NULL,
  `AddressAddition` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `ZipCode` varchar(10) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Wage` decimal(10,0) NOT NULL,
  `AccountNumber` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Status` int(11) NOT NULL,
  `DepartmentID` int(11) NOT NULL,
  `ContractID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`ID`, `BirthDate`, `HireDate`, `LastWorkingDay`, `Country`, `City`, `Street`, `StreetNumber`, `AddressAddition`, `ZipCode`, `Wage`, `AccountNumber`, `Status`, `DepartmentID`, `ContractID`) VALUES
(3, '1990-12-14 00:00:00', '2021-03-01 00:00:00', '2021-05-19 12:31:44', 'Netherlands', 'Amsterdam', 'Plateelplaats', 156, '', '2871JA', '12', 'ABN9493948252201', 1, 3, 1),
(25, '1990-05-30 00:00:00', '2020-05-30 00:00:00', '2021-05-20 12:31:47', 'S', 'S', 'S', 0, '', 'S', '16', 'VBMN321321', 2, 2, 2),
(26, '1990-05-30 00:00:00', '2020-05-30 00:00:00', '2021-06-25 00:00:00', 'SE', 'S', 'S', 0, '', 'S', '16', 'VBMN321321', 3, 2, 2),
(30, '1990-05-30 00:00:00', '2020-05-30 00:00:00', '2021-07-15 12:31:22', 'S', 'S', 'S', 0, '', 'S', '16', 'VBMN321321', 1, 2, 2),
(31, '1990-05-30 00:00:00', '2020-05-30 00:00:00', '0001-01-01 00:00:00', 'S', 'S', 'S', 0, '', 'S', '16', 'VBMN321321', 2, 2, 2),
(32, '1990-05-30 00:00:00', '2020-05-30 00:00:00', NULL, 'S', 'S', 'S', 0, '', 'S', '16', 'VBMN321321', 2, 2, 2),
(33, '1990-05-30 00:00:00', '2020-05-30 00:00:00', '2022-01-01 00:00:00', 'Sd', 'Sd', 'Sd', 10, 'sad', 'Sd', '19', 'VBMN321321', 2, 3, 3),
(34, '1992-01-02 00:00:00', '2021-03-10 00:00:00', NULL, 'Netherlands', 'Eindhoven', 'Steet', 2, '', '', '10', 'sdasadsa', 2, 2, 2);

-- --------------------------------------------------------

--
-- Table structure for table `employeeassignment`
--

CREATE TABLE `employeeassignment` (
  `ID` int(11) NOT NULL,
  `ShiftID` int(11) NOT NULL,
  `EmployeeID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `employeeassignment`
--

INSERT INTO `employeeassignment` (`ID`, `ShiftID`, `EmployeeID`) VALUES
(10, 4, 30),
(6, 5, 25),
(9, 5, 26),
(8, 5, 32),
(11, 8, 3),
(13, 15, 30),
(12, 15, 31),
(14, 29, 34),
(17, 36, 26),
(18, 36, 30),
(19, 37, 26),
(20, 37, 30),
(21, 38, 3),
(23, 38, 33),
(22, 38, 34);

-- --------------------------------------------------------

--
-- Table structure for table `employeestatus`
--

CREATE TABLE `employeestatus` (
  `ID` int(11) NOT NULL,
  `Status` varchar(25) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `employeestatus`
--

INSERT INTO `employeestatus` (`ID`, `Status`) VALUES
(1, 'NOT_STARTED'),
(2, 'WORKING'),
(3, 'STOPPED');

-- --------------------------------------------------------

--
-- Table structure for table `person`
--

CREATE TABLE `person` (
  `ID` int(11) NOT NULL,
  `FirstName` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `LastName` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Email` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Username` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Password` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `AccessLevel` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `person`
--

INSERT INTO `person` (`ID`, `FirstName`, `LastName`, `Email`, `Username`, `Password`, `AccessLevel`) VALUES
(1, 'Bohdan', 'Tymofieienko', 'a@b.com', 'bohtym05', 'test', 2),
(2, 'John', 'Brown', 'jb@mb.com', 'johbro03', 'pass', 3),
(3, 'Connor', 'Rube', 'cr@n.com', 'conrob08', 'test', 1),
(25, 'A', 'A', 'A3434', 'A', 'test', 1),
(26, 'A', 'A', 'A33', 'A33', 'test', 1),
(28, 'A', 'A', 'A354', 'A354', 'test', 1),
(30, 'A', 'A', 'A334', 'A334', 'test', 1),
(31, 'A', 'A', 'A3242334', 'A3242334', 'test', 1),
(32, 'A', 'A', 'A774', 'A774', 'test', 1),
(33, 'A', 'A', 'A7fdsf745', 'A7fdsf74', 'test', 1),
(34, 'George', 'Chan', 'adsa', 'adsa', 'test', 1);

-- --------------------------------------------------------

--
-- Table structure for table `shifttime`
--

CREATE TABLE `shifttime` (
  `ID` int(11) NOT NULL,
  `Name` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `shifttime`
--

INSERT INTO `shifttime` (`ID`, `Name`) VALUES
(2, 'Day'),
(1, 'Morning'),
(3, 'Night');

-- --------------------------------------------------------

--
-- Table structure for table `workshift`
--

CREATE TABLE `workshift` (
  `ID` int(11) NOT NULL,
  `ShiftType` int(11) NOT NULL,
  `Date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `workshift`
--

INSERT INTO `workshift` (`ID`, `ShiftType`, `Date`) VALUES
(17, 1, '2021-03-02 07:00:00'),
(8, 1, '2021-03-10 07:00:00'),
(16, 1, '2021-03-13 07:00:00'),
(13, 1, '2021-03-17 07:00:00'),
(11, 1, '2021-03-21 07:00:00'),
(4, 1, '2021-03-22 07:00:00'),
(34, 1, '2021-03-27 07:00:00'),
(33, 1, '2021-04-09 07:00:00'),
(23, 1, '2021-05-18 07:00:00'),
(32, 1, '2021-07-14 07:00:00'),
(27, 2, '2021-03-02 15:00:00'),
(28, 2, '2021-03-13 15:00:00'),
(5, 2, '2021-03-15 15:00:00'),
(15, 2, '2021-03-18 15:00:00'),
(36, 2, '2021-03-20 15:00:00'),
(22, 2, '2021-03-31 10:05:26'),
(18, 2, '2021-04-03 15:00:00'),
(19, 2, '2021-04-04 15:00:00'),
(30, 2, '2021-07-10 15:00:00'),
(37, 2, '2021-08-10 15:00:00'),
(38, 2, '2021-12-10 15:00:00'),
(12, 3, '2021-03-12 23:00:00'),
(24, 3, '2021-03-17 23:00:00'),
(26, 3, '2021-03-24 23:00:00'),
(14, 3, '2021-03-25 23:00:00'),
(29, 3, '2021-03-26 23:00:00'),
(20, 3, '2021-03-31 10:05:26'),
(25, 3, '2021-05-17 23:00:00'),
(31, 3, '2021-07-16 23:00:00');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `accesslevel`
--
ALTER TABLE `accesslevel`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `Name` (`Name`);

--
-- Indexes for table `contract`
--
ALTER TABLE `contract`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `department`
--
ALTER TABLE `department`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `Name` (`Name`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD UNIQUE KEY `ID` (`ID`),
  ADD KEY `DepartmentID` (`DepartmentID`),
  ADD KEY `ContractID` (`ContractID`),
  ADD KEY `Status` (`Status`);

--
-- Indexes for table `employeeassignment`
--
ALTER TABLE `employeeassignment`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `ShiftID_2` (`ShiftID`,`EmployeeID`),
  ADD KEY `ShiftID` (`ShiftID`),
  ADD KEY `EmployeeID` (`EmployeeID`);

--
-- Indexes for table `employeestatus`
--
ALTER TABLE `employeestatus`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `person`
--
ALTER TABLE `person`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `Username` (`Username`),
  ADD UNIQUE KEY `Email` (`Email`),
  ADD KEY `AccessLevel` (`AccessLevel`);

--
-- Indexes for table `shifttime`
--
ALTER TABLE `shifttime`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `Name` (`Name`);

--
-- Indexes for table `workshift`
--
ALTER TABLE `workshift`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `ShiftType_2` (`ShiftType`,`Date`),
  ADD KEY `ShiftType` (`ShiftType`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `accesslevel`
--
ALTER TABLE `accesslevel`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `contract`
--
ALTER TABLE `contract`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `department`
--
ALTER TABLE `department`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `employeeassignment`
--
ALTER TABLE `employeeassignment`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT for table `employeestatus`
--
ALTER TABLE `employeestatus`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `person`
--
ALTER TABLE `person`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT for table `shifttime`
--
ALTER TABLE `shifttime`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `workshift`
--
ALTER TABLE `workshift`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `employee`
--
ALTER TABLE `employee`
  ADD CONSTRAINT `employee_ibfk_1` FOREIGN KEY (`ID`) REFERENCES `person` (`ID`),
  ADD CONSTRAINT `employee_ibfk_2` FOREIGN KEY (`DepartmentID`) REFERENCES `department` (`ID`),
  ADD CONSTRAINT `employee_ibfk_3` FOREIGN KEY (`ContractID`) REFERENCES `contract` (`ID`),
  ADD CONSTRAINT `employee_ibfk_4` FOREIGN KEY (`Status`) REFERENCES `employeestatus` (`ID`);

--
-- Constraints for table `employeeassignment`
--
ALTER TABLE `employeeassignment`
  ADD CONSTRAINT `employeeassignment_ibfk_1` FOREIGN KEY (`ShiftID`) REFERENCES `workshift` (`ID`),
  ADD CONSTRAINT `employeeassignment_ibfk_2` FOREIGN KEY (`EmployeeID`) REFERENCES `employee` (`ID`);

--
-- Constraints for table `person`
--
ALTER TABLE `person`
  ADD CONSTRAINT `person_ibfk_1` FOREIGN KEY (`AccessLevel`) REFERENCES `accesslevel` (`ID`);

--
-- Constraints for table `workshift`
--
ALTER TABLE `workshift`
  ADD CONSTRAINT `workshift_ibfk_1` FOREIGN KEY (`ShiftType`) REFERENCES `shifttime` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
