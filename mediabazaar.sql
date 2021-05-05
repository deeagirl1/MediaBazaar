-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 05, 2021 at 01:54 PM
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
-- Table structure for table `annoucements`
--

CREATE TABLE `annoucements` (
  `ID` int(11) NOT NULL,
  `Title` tinytext NOT NULL,
  `Description` text NOT NULL,
  `PostDate` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `annoucements`
--

INSERT INTO `annoucements` (`ID`, `Title`, `Description`, `PostDate`) VALUES
(1, 'Delay', 'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum', '2021-04-16 00:00:00'),
(2, 'What is Lorem Ipsum?', 'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum', '2021-04-20 17:23:39'),
(3, 'Test', 'Test', '2021-04-29 09:03:04');

-- --------------------------------------------------------

--
-- Table structure for table `contactmessages`
--

CREATE TABLE `contactmessages` (
  `ID` int(11) NOT NULL,
  `Sender` int(11) NOT NULL,
  `Topic` tinytext NOT NULL,
  `Text` text NOT NULL,
  `DateTime` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `contactmessages`
--

INSERT INTO `contactmessages` (`ID`, `Sender`, `Topic`, `Text`, `DateTime`) VALUES
(1, 41, 'Test', 'test', '2021-04-15 20:57:52'),
(2, 39, 'Text', 'text\r\n', '2021-04-15 21:40:45');

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
  `ContractID` int(11) NOT NULL,
  `NightShifts` tinyint(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`ID`, `BirthDate`, `HireDate`, `LastWorkingDay`, `Country`, `City`, `Street`, `StreetNumber`, `AddressAddition`, `ZipCode`, `Wage`, `AccountNumber`, `Status`, `DepartmentID`, `ContractID`, `NightShifts`) VALUES
(39, '1995-04-18 00:00:00', '2020-10-14 00:00:00', NULL, 'Indonesia', 'Cibojong', 'Birch Street', 22, '', '23141', '13', '7872364832', 2, 2, 1, 1),
(40, '1988-06-09 00:00:00', '2021-03-01 00:00:00', '2021-06-01 00:00:00', 'Czech Republic', 'Jablonné', 'Rowland Court', 7, '', '86776', '10', '0643387161', 2, 2, 1, 1),
(41, '1994-09-23 00:00:00', '2021-04-01 00:00:00', NULL, 'USA', 'Detroit', 'Brookside', 4, 'Michigan', '42343', '5', '4532625841057', 1, 3, 2, 1),
(42, '1990-12-04 00:00:00', '2020-12-20 00:00:00', '2022-12-31 00:00:00', 'UK', 'London', 'Brick Lane', 12, '', '98672', '16', '543254354235', 2, 2, 3, 1);

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
(108, 98, 41),
(109, 99, 41),
(110, 100, 41),
(111, 101, 41),
(112, 102, 39),
(113, 102, 40),
(114, 103, 40),
(115, 104, 40),
(116, 105, 41),
(117, 106, 39),
(118, 107, 39),
(119, 108, 39),
(120, 109, 39);

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
(35, 'Joyan', 'Jasper', 'jjasper2@mb.com', 'admin1', 'pass', 2),
(36, 'Darill', 'Skatcher', 'dskatchern@mb.com', 'manager1', 'pass', 3),
(39, 'Juana', 'Chiommienti', 'jchiommienti1@mb.com', 'jchiommienti1@mb.com', 'test', 1),
(40, 'Farlay', 'Giamuzzo', 'fgiamuzzoj@mb.com', 'fgiamuzzoj@mb.com', 'test', 1),
(41, 'Ryan', 'Branham', 'rbranham@mb.com', 'rbranham@mb.com', 'test', 1),
(42, 'Ryan', 'Harris', 'rharris@mb.com', 'rharris@mb.com', 'test', 1),
(44, 'John', 'Doe', 'jdoe@mb.com', 'johdoe', 'pass', 2),
(47, 'John', 'Doe', 'jdoe1@mb.com', 'johdoe61', 'OYBVUJLN', 2);

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `ID` int(11) NOT NULL,
  `Name` text NOT NULL,
  `Department` int(11) NOT NULL,
  `CostPrice` decimal(11,0) NOT NULL,
  `SellingPrice` decimal(11,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`ID`, `Name`, `Department`, `CostPrice`, `SellingPrice`) VALUES
(2, 'Chair', 1, '10', '12');

-- --------------------------------------------------------

--
-- Table structure for table `productstock`
--

CREATE TABLE `productstock` (
  `ID` int(11) NOT NULL,
  `NrInStock` int(11) NOT NULL,
  `MinThreshold` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `productstock`
--

INSERT INTO `productstock` (`ID`, `NrInStock`, `MinThreshold`) VALUES
(2, 10, 5);

-- --------------------------------------------------------

--
-- Table structure for table `requeststatus`
--

CREATE TABLE `requeststatus` (
  `ID` int(11) NOT NULL,
  `Name` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `requeststatus`
--

INSERT INTO `requeststatus` (`ID`, `Name`) VALUES
(1, 'Pending'),
(2, 'Accepted'),
(3, 'Rejected');

-- --------------------------------------------------------

--
-- Table structure for table `restock`
--

CREATE TABLE `restock` (
  `ID` int(11) NOT NULL,
  `ItemID` int(11) NOT NULL,
  `AmountRequested` int(11) NOT NULL,
  `Date` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `restock`
--

INSERT INTO `restock` (`ID`, `ItemID`, `AmountRequested`, `Date`) VALUES
(2, 2, 10, '2021-05-05 10:42:34');

-- --------------------------------------------------------

--
-- Table structure for table `shiftpreference`
--

CREATE TABLE `shiftpreference` (
  `ID` int(11) NOT NULL,
  `Employee` int(11) NOT NULL,
  `Day` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `shiftpreference`
--

INSERT INTO `shiftpreference` (`ID`, `Employee`, `Day`) VALUES
(48, 41, 3),
(49, 41, 6);

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
-- Table structure for table `weekday`
--

CREATE TABLE `weekday` (
  `ID` int(11) NOT NULL,
  `Day` varchar(15) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `weekday`
--

INSERT INTO `weekday` (`ID`, `Day`) VALUES
(1, 'Monday'),
(2, 'Tuesday'),
(3, 'Wednesday'),
(4, 'Thursday'),
(5, 'Friday'),
(6, 'Saturday'),
(7, 'Sunday');

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
(102, 1, '2021-03-01 07:00:00'),
(105, 1, '2021-04-12 07:00:00'),
(98, 1, '2021-04-14 07:00:00'),
(101, 1, '2021-04-16 07:00:00'),
(108, 1, '2021-04-28 07:00:00'),
(104, 2, '2021-04-10 15:00:00'),
(100, 2, '2021-04-15 15:00:00'),
(106, 2, '2021-04-23 15:00:00'),
(107, 2, '2021-04-26 15:00:00'),
(103, 2, '2021-05-09 15:00:00'),
(99, 3, '2021-04-14 23:00:00'),
(109, 3, '2021-04-29 23:00:00'),
(110, 3, '2021-04-30 23:00:00');

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
-- Indexes for table `annoucements`
--
ALTER TABLE `annoucements`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `contactmessages`
--
ALTER TABLE `contactmessages`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Sender` (`Sender`);

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
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Department` (`Department`);

--
-- Indexes for table `productstock`
--
ALTER TABLE `productstock`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `requeststatus`
--
ALTER TABLE `requeststatus`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restock`
--
ALTER TABLE `restock`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ItemID` (`ItemID`);

--
-- Indexes for table `shiftpreference`
--
ALTER TABLE `shiftpreference`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Employee` (`Employee`),
  ADD KEY `Day` (`Day`);

--
-- Indexes for table `shifttime`
--
ALTER TABLE `shifttime`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `Name` (`Name`);

--
-- Indexes for table `weekday`
--
ALTER TABLE `weekday`
  ADD PRIMARY KEY (`ID`);

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
-- AUTO_INCREMENT for table `annoucements`
--
ALTER TABLE `annoucements`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `contactmessages`
--
ALTER TABLE `contactmessages`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

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
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=122;

--
-- AUTO_INCREMENT for table `employeestatus`
--
ALTER TABLE `employeestatus`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `person`
--
ALTER TABLE `person`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=48;

--
-- AUTO_INCREMENT for table `product`
--
ALTER TABLE `product`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `requeststatus`
--
ALTER TABLE `requeststatus`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `restock`
--
ALTER TABLE `restock`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `shiftpreference`
--
ALTER TABLE `shiftpreference`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=50;

--
-- AUTO_INCREMENT for table `shifttime`
--
ALTER TABLE `shifttime`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `workshift`
--
ALTER TABLE `workshift`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=111;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `contactmessages`
--
ALTER TABLE `contactmessages`
  ADD CONSTRAINT `contactmessages_ibfk_1` FOREIGN KEY (`Sender`) REFERENCES `person` (`ID`);

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
-- Constraints for table `product`
--
ALTER TABLE `product`
  ADD CONSTRAINT `product_ibfk_2` FOREIGN KEY (`Department`) REFERENCES `department` (`ID`);

--
-- Constraints for table `productstock`
--
ALTER TABLE `productstock`
  ADD CONSTRAINT `productstock_ibfk_1` FOREIGN KEY (`ID`) REFERENCES `product` (`ID`);

--
-- Constraints for table `restock`
--
ALTER TABLE `restock`
  ADD CONSTRAINT `restock_ibfk_1` FOREIGN KEY (`ItemID`) REFERENCES `product` (`ID`);

--
-- Constraints for table `shiftpreference`
--
ALTER TABLE `shiftpreference`
  ADD CONSTRAINT `shiftpreference_ibfk_1` FOREIGN KEY (`Employee`) REFERENCES `employee` (`ID`),
  ADD CONSTRAINT `shiftpreference_ibfk_2` FOREIGN KEY (`Day`) REFERENCES `weekday` (`ID`);

--
-- Constraints for table `workshift`
--
ALTER TABLE `workshift`
  ADD CONSTRAINT `workshift_ibfk_1` FOREIGN KEY (`ShiftType`) REFERENCES `shifttime` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
