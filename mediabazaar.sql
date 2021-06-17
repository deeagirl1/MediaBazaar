-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 17, 2021 at 05:46 PM
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
(5, 'Cashier'),
(6, 'DepartmentManager'),
(4, 'DepotWorker'),
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
(3, 'Test', 'Testing', '2021-04-29 09:03:04');

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
  `Name` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Manager` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `department`
--

INSERT INTO `department` (`ID`, `Name`, `Manager`) VALUES
(1, 'Household', 39),
(2, 'Electronics', 42),
(3, 'Cashier', 40),
(15, 'Test5', 58);

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
  `NightShifts` tinyint(1) NOT NULL DEFAULT 1,
  `IsDepManager` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`ID`, `BirthDate`, `HireDate`, `LastWorkingDay`, `Country`, `City`, `Street`, `StreetNumber`, `AddressAddition`, `ZipCode`, `Wage`, `AccountNumber`, `Status`, `DepartmentID`, `ContractID`, `NightShifts`, `IsDepManager`) VALUES
(39, '1995-04-18 00:00:00', '2020-10-14 00:00:00', NULL, 'Indonesia', 'Cibojong', 'Birch Street', 22, '', '23141', '13', '7872364832', 2, 2, 1, 1, 2),
(40, '1988-06-09 00:00:00', '2021-03-01 00:00:00', '2021-06-01 00:00:00', 'Czech Republic', 'Jablonné', 'Rowland Court', 7, '', '86776', '10', '0643387161', 2, 2, 1, 1, 2),
(41, '1994-09-23 00:00:00', '2021-04-01 00:00:00', NULL, 'USA', 'Detroit', 'Brookside', 4, 'Michigan', '42343', '5', '4532625841057', 1, 3, 2, 1, 2),
(42, '1990-12-04 00:00:00', '2020-12-20 00:00:00', '2022-12-31 00:00:00', 'UK', 'London', 'Brick Lane', 12, '', '98672', '16', '543254354235', 2, 2, 3, 1, 0),
(58, '1999-10-20 00:00:00', '2021-05-05 00:00:00', NULL, 'sdafsda', 'sdafsad', 'fdsaf', 213, 'fsdadsaf', '32432', '45', 'sdafsda', 2, 2, 1, 1, 2),
(59, '2000-10-01 00:00:00', '2021-01-01 00:00:00', NULL, 'sdafdsa', 'sdafasd', 'fsdaf', 12, 'sdf', 'fasdfds', '10', 'fsdafds', 2, 3, 1, 1, 2),
(60, '2000-01-01 00:00:00', '2021-01-01 00:00:00', NULL, 'asdfda', 'sdasdf', 'asdfs', 213, 'fsdafdsa', '4231423', '8', 'sadfsd', 2, 3, 1, 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `employeeassignment`
--

CREATE TABLE `employeeassignment` (
  `ID` int(11) NOT NULL,
  `ShiftID` int(11) NOT NULL,
  `EmployeeID` int(11) NOT NULL,
  `CheckIn` datetime DEFAULT NULL,
  `CheckOut` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `employeeassignment`
--

INSERT INTO `employeeassignment` (`ID`, `ShiftID`, `EmployeeID`, `CheckIn`, `CheckOut`) VALUES
(198, 135, 39, '2021-06-04 18:29:33', NULL),
(199, 135, 42, NULL, NULL),
(200, 135, 58, NULL, NULL),
(201, 135, 59, NULL, NULL),
(202, 135, 60, NULL, NULL),
(203, 137, 39, NULL, NULL),
(204, 137, 42, NULL, NULL),
(205, 137, 58, NULL, NULL),
(206, 137, 59, NULL, NULL),
(207, 137, 60, NULL, NULL),
(208, 139, 39, NULL, NULL),
(209, 139, 41, NULL, NULL),
(210, 139, 42, NULL, NULL),
(211, 139, 58, NULL, NULL),
(212, 139, 59, NULL, NULL),
(213, 139, 60, NULL, NULL),
(214, 141, 39, NULL, NULL),
(215, 141, 41, NULL, NULL),
(216, 141, 42, NULL, NULL),
(217, 141, 58, NULL, NULL),
(218, 141, 59, NULL, NULL),
(219, 141, 60, NULL, NULL),
(220, 143, 39, NULL, NULL),
(221, 143, 41, NULL, NULL),
(222, 143, 42, NULL, NULL),
(223, 143, 58, NULL, NULL),
(224, 143, 59, NULL, NULL),
(225, 143, 60, NULL, NULL),
(226, 145, 39, NULL, NULL),
(227, 145, 41, NULL, NULL),
(228, 145, 42, NULL, NULL),
(229, 145, 58, NULL, NULL),
(230, 145, 59, NULL, NULL),
(231, 145, 60, NULL, NULL),
(232, 147, 39, NULL, NULL),
(233, 147, 42, NULL, NULL),
(234, 147, 58, NULL, NULL),
(235, 147, 59, NULL, NULL),
(236, 147, 60, NULL, NULL),
(237, 157, 39, NULL, NULL),
(238, 157, 58, NULL, NULL),
(239, 157, 59, NULL, NULL),
(240, 158, 60, NULL, NULL),
(241, 158, 41, '2021-06-04 18:53:29', '2021-06-04 18:55:32'),
(242, 158, 42, NULL, NULL),
(243, 159, 39, NULL, NULL),
(244, 159, 58, NULL, NULL),
(245, 159, 59, NULL, NULL),
(246, 160, 60, NULL, NULL),
(247, 160, 41, NULL, NULL),
(248, 160, 42, NULL, NULL),
(249, 161, 39, NULL, NULL),
(250, 161, 58, NULL, NULL),
(251, 161, 59, NULL, NULL),
(252, 162, 60, NULL, NULL),
(253, 162, 42, NULL, NULL),
(254, 163, 39, NULL, NULL),
(255, 163, 58, NULL, NULL),
(256, 163, 59, NULL, NULL),
(257, 164, 60, NULL, NULL),
(258, 164, 42, NULL, NULL),
(259, 165, 39, NULL, NULL),
(260, 165, 58, NULL, NULL),
(261, 165, 59, NULL, NULL),
(262, 166, 60, NULL, NULL),
(263, 166, 42, NULL, NULL),
(264, 167, 39, NULL, NULL),
(265, 167, 58, NULL, NULL),
(266, 167, 59, NULL, NULL),
(267, 168, 60, NULL, NULL),
(268, 168, 41, NULL, NULL),
(269, 168, 42, NULL, NULL),
(270, 169, 39, NULL, NULL),
(271, 169, 58, NULL, NULL),
(272, 169, 59, NULL, NULL),
(273, 170, 60, NULL, NULL),
(274, 170, 41, NULL, NULL),
(275, 170, 42, NULL, NULL),
(276, 171, 39, NULL, NULL),
(277, 171, 58, NULL, NULL),
(278, 171, 59, NULL, NULL),
(279, 172, 60, NULL, NULL),
(280, 172, 41, NULL, NULL),
(281, 172, 42, NULL, NULL),
(282, 173, 39, NULL, NULL),
(283, 173, 58, NULL, NULL),
(284, 173, 59, NULL, NULL),
(285, 174, 60, NULL, NULL),
(286, 174, 41, NULL, NULL),
(287, 174, 42, NULL, NULL),
(288, 175, 39, NULL, NULL),
(289, 175, 58, NULL, NULL),
(290, 175, 59, NULL, NULL),
(291, 176, 60, NULL, NULL),
(292, 176, 42, NULL, NULL),
(293, 188, 39, NULL, NULL),
(294, 188, 58, NULL, NULL),
(295, 189, 59, NULL, NULL),
(296, 189, 60, NULL, NULL),
(297, 190, 39, NULL, NULL),
(298, 190, 58, NULL, NULL),
(299, 191, 59, NULL, NULL),
(300, 191, 60, NULL, NULL),
(301, 192, 39, NULL, NULL),
(302, 192, 58, NULL, NULL),
(303, 193, 59, NULL, NULL),
(304, 193, 60, NULL, NULL),
(305, 194, 39, NULL, NULL),
(306, 194, 58, NULL, NULL),
(307, 195, 59, NULL, NULL),
(308, 195, 60, NULL, NULL),
(309, 196, 39, NULL, NULL),
(310, 196, 58, NULL, NULL),
(311, 197, 59, NULL, NULL),
(312, 197, 60, NULL, NULL),
(313, 198, 39, NULL, NULL),
(314, 198, 58, NULL, NULL),
(315, 199, 59, NULL, NULL),
(316, 199, 60, NULL, NULL),
(317, 200, 39, NULL, NULL),
(318, 200, 58, NULL, NULL),
(319, 201, 59, NULL, NULL),
(320, 201, 60, NULL, NULL),
(321, 202, 41, NULL, NULL),
(322, 202, 42, NULL, NULL),
(323, 204, 41, NULL, NULL),
(324, 204, 42, NULL, NULL),
(325, 206, 41, NULL, NULL),
(326, 206, 42, NULL, NULL),
(327, 208, 42, NULL, NULL),
(328, 210, 42, NULL, NULL),
(329, 213, 39, NULL, NULL),
(330, 213, 58, NULL, NULL),
(331, 214, 59, NULL, NULL),
(332, 214, 60, NULL, NULL),
(333, 215, 39, NULL, NULL),
(334, 215, 58, NULL, NULL),
(335, 216, 59, NULL, NULL),
(336, 216, 60, NULL, NULL),
(337, 217, 39, NULL, NULL),
(338, 217, 58, NULL, NULL),
(339, 218, 59, NULL, NULL),
(340, 218, 60, NULL, NULL),
(341, 219, 39, NULL, NULL),
(342, 220, 58, NULL, NULL),
(343, 221, 39, NULL, NULL),
(344, 222, 58, NULL, NULL),
(345, 223, 39, NULL, NULL),
(346, 224, 58, NULL, NULL),
(347, 225, 39, NULL, NULL),
(348, 226, 58, NULL, NULL),
(349, 227, 39, NULL, NULL),
(350, 228, 58, NULL, NULL),
(351, 229, 59, NULL, NULL),
(352, 230, 60, NULL, NULL),
(353, 231, 59, NULL, NULL),
(354, 232, 60, NULL, NULL),
(355, 233, 59, NULL, NULL),
(356, 234, 60, NULL, NULL),
(357, 235, 39, NULL, NULL),
(358, 236, 58, NULL, NULL),
(359, 237, 39, NULL, NULL),
(360, 238, 58, NULL, NULL),
(361, 239, 39, NULL, NULL),
(362, 240, 58, NULL, NULL),
(363, 241, 39, NULL, NULL),
(364, 242, 58, NULL, NULL),
(365, 243, 39, NULL, NULL),
(366, 244, 58, NULL, NULL),
(367, 245, 59, NULL, NULL),
(368, 246, 60, NULL, NULL),
(369, 247, 59, NULL, NULL),
(370, 248, 60, NULL, NULL),
(371, 249, 59, NULL, NULL),
(372, 250, 39, NULL, NULL),
(373, 250, 40, NULL, NULL),
(374, 251, 58, NULL, NULL),
(375, 251, 59, NULL, NULL),
(376, 252, 39, NULL, NULL),
(377, 252, 40, NULL, NULL),
(378, 253, 58, NULL, NULL),
(379, 253, 59, NULL, NULL),
(380, 254, 39, NULL, NULL),
(381, 254, 40, NULL, NULL),
(382, 255, 58, NULL, NULL),
(383, 255, 59, NULL, NULL),
(384, 256, 39, NULL, NULL),
(385, 256, 40, NULL, NULL),
(386, 257, 39, NULL, NULL),
(387, 257, 58, NULL, NULL),
(388, 258, 59, NULL, NULL),
(389, 258, 60, NULL, NULL),
(390, 259, 39, NULL, NULL),
(391, 259, 58, NULL, NULL),
(392, 260, 59, NULL, NULL),
(393, 260, 60, NULL, NULL),
(394, 261, 39, NULL, NULL),
(395, 261, 58, NULL, NULL),
(396, 262, 59, NULL, NULL),
(397, 262, 60, NULL, NULL),
(398, 263, 39, NULL, NULL),
(399, 263, 58, NULL, NULL),
(400, 264, 59, NULL, NULL),
(401, 264, 60, NULL, NULL),
(402, 265, 39, NULL, NULL),
(403, 265, 58, NULL, NULL),
(404, 266, 59, NULL, NULL),
(405, 266, 60, NULL, NULL),
(406, 267, 42, NULL, NULL),
(407, 269, 39, NULL, NULL),
(408, 269, 58, NULL, NULL),
(409, 270, 59, NULL, NULL),
(410, 270, 60, NULL, NULL),
(411, 271, 39, NULL, NULL),
(412, 271, 58, NULL, NULL),
(415, 273, 39, NULL, NULL),
(416, 273, 58, NULL, NULL),
(417, 274, 59, NULL, NULL),
(418, 274, 60, NULL, NULL),
(419, 275, 39, NULL, NULL),
(420, 275, 58, NULL, NULL),
(421, 276, 59, NULL, NULL),
(422, 276, 60, NULL, NULL),
(423, 277, 39, NULL, NULL),
(424, 277, 58, NULL, NULL),
(425, 278, 59, NULL, NULL),
(426, 278, 60, NULL, NULL),
(427, 279, 41, NULL, NULL),
(428, 279, 42, NULL, NULL),
(429, 281, 41, NULL, NULL),
(430, 281, 42, NULL, NULL),
(431, 283, 41, NULL, NULL),
(432, 283, 42, NULL, NULL),
(433, 285, 42, NULL, NULL),
(434, 287, 42, NULL, NULL),
(435, 290, 39, NULL, NULL),
(436, 290, 58, NULL, NULL),
(437, 291, 59, NULL, NULL),
(438, 291, 60, NULL, NULL),
(439, 292, 39, NULL, NULL),
(440, 292, 58, NULL, NULL),
(441, 293, 59, NULL, NULL),
(442, 293, 60, NULL, NULL),
(443, 294, 39, NULL, NULL),
(444, 294, 58, NULL, NULL),
(445, 295, 59, NULL, NULL),
(446, 295, 60, NULL, NULL),
(447, 296, 39, NULL, NULL),
(448, 296, 58, NULL, NULL),
(449, 297, 59, NULL, NULL),
(450, 297, 60, NULL, NULL),
(451, 298, 39, NULL, NULL),
(452, 298, 58, NULL, NULL),
(453, 299, 59, NULL, NULL),
(454, 299, 60, NULL, NULL),
(455, 300, 41, NULL, NULL),
(456, 300, 42, NULL, NULL),
(457, 302, 39, NULL, NULL),
(458, 302, 58, NULL, NULL),
(459, 303, 59, NULL, NULL),
(460, 303, 60, NULL, NULL),
(461, 304, 39, NULL, NULL),
(462, 304, 58, NULL, NULL),
(463, 305, 59, NULL, NULL),
(464, 305, 60, NULL, NULL),
(465, 306, 39, NULL, NULL),
(466, 306, 58, NULL, NULL),
(467, 307, 59, NULL, NULL),
(468, 307, 60, NULL, NULL),
(469, 308, 39, NULL, NULL),
(470, 308, 58, NULL, NULL),
(471, 309, 59, NULL, NULL),
(472, 309, 60, NULL, NULL),
(473, 310, 39, NULL, NULL),
(474, 310, 58, NULL, NULL),
(475, 311, 59, NULL, NULL),
(476, 311, 60, NULL, NULL),
(477, 312, 41, NULL, NULL),
(478, 312, 42, NULL, NULL),
(479, 314, 41, NULL, NULL),
(480, 314, 42, NULL, NULL),
(481, 316, 41, NULL, NULL),
(482, 316, 42, NULL, NULL),
(483, 318, 42, NULL, NULL),
(484, 272, 59, NULL, NULL),
(485, 272, 60, NULL, NULL),
(486, 272, 41, NULL, NULL),
(487, 320, 41, NULL, NULL),
(488, 320, 42, NULL, NULL),
(489, 322, 41, NULL, NULL),
(490, 322, 42, NULL, NULL),
(491, 324, 42, NULL, NULL),
(492, 326, 42, NULL, NULL),
(493, 329, 39, NULL, NULL),
(494, 329, 58, NULL, NULL),
(495, 330, 59, NULL, NULL),
(496, 330, 60, NULL, NULL),
(497, 331, 39, NULL, NULL),
(498, 331, 58, NULL, NULL),
(499, 332, 59, NULL, NULL),
(500, 332, 60, NULL, NULL),
(501, 333, 39, NULL, NULL),
(502, 333, 58, NULL, NULL),
(503, 334, 59, NULL, NULL),
(504, 334, 60, NULL, NULL),
(505, 335, 39, NULL, NULL),
(506, 335, 58, NULL, NULL),
(507, 336, 59, NULL, NULL),
(508, 336, 60, NULL, NULL),
(509, 337, 39, NULL, NULL),
(510, 337, 58, NULL, NULL),
(511, 338, 59, NULL, NULL),
(512, 338, 60, NULL, NULL),
(513, 339, 41, NULL, NULL),
(514, 339, 42, NULL, NULL),
(515, 341, 41, NULL, NULL),
(516, 341, 42, NULL, NULL),
(517, 343, 41, NULL, NULL),
(518, 343, 42, NULL, NULL),
(519, 345, 42, NULL, NULL),
(520, 347, 42, NULL, NULL),
(521, 350, 39, NULL, NULL),
(522, 350, 58, NULL, NULL),
(523, 351, 59, NULL, NULL),
(524, 351, 60, NULL, NULL),
(525, 352, 39, NULL, NULL),
(526, 352, 58, NULL, NULL),
(527, 353, 59, NULL, NULL),
(528, 353, 60, NULL, NULL),
(529, 354, 39, NULL, NULL),
(530, 354, 58, NULL, NULL),
(531, 355, 59, NULL, NULL),
(532, 355, 60, NULL, NULL),
(533, 356, 39, NULL, NULL),
(534, 356, 58, NULL, NULL),
(535, 357, 59, NULL, NULL),
(536, 357, 60, NULL, NULL),
(537, 358, 39, NULL, NULL),
(538, 358, 58, NULL, NULL),
(539, 359, 59, NULL, NULL),
(540, 359, 60, NULL, NULL),
(541, 360, 41, NULL, NULL),
(542, 360, 42, NULL, NULL),
(543, 362, 41, NULL, NULL),
(544, 362, 42, NULL, NULL),
(545, 364, 41, NULL, NULL),
(546, 364, 42, NULL, NULL),
(547, 365, 39, NULL, NULL),
(548, 365, 58, NULL, NULL),
(549, 366, 59, NULL, NULL),
(550, 366, 60, NULL, NULL),
(551, 367, 39, NULL, NULL),
(552, 367, 58, NULL, NULL),
(553, 368, 59, NULL, NULL),
(554, 368, 60, NULL, NULL),
(555, 369, 39, NULL, NULL),
(556, 369, 58, NULL, NULL),
(557, 370, 59, NULL, NULL),
(558, 370, 60, NULL, NULL),
(559, 371, 41, NULL, NULL),
(560, 372, 42, NULL, NULL),
(561, 373, 41, NULL, NULL),
(562, 374, 42, NULL, NULL),
(563, 375, 41, NULL, NULL),
(564, 376, 42, NULL, NULL),
(565, 377, 42, NULL, NULL),
(566, 380, 39, NULL, NULL),
(567, 380, 58, NULL, NULL),
(568, 381, 59, NULL, NULL),
(569, 381, 60, NULL, NULL),
(570, 382, 39, NULL, NULL),
(571, 382, 58, NULL, NULL),
(572, 383, 59, NULL, NULL),
(573, 383, 60, NULL, NULL),
(574, 384, 39, NULL, NULL),
(575, 384, 58, NULL, NULL),
(576, 385, 59, NULL, NULL),
(577, 385, 60, NULL, NULL),
(578, 386, 39, NULL, NULL),
(579, 386, 58, NULL, NULL),
(580, 387, 59, NULL, NULL),
(581, 387, 60, NULL, NULL),
(582, 388, 39, NULL, NULL),
(583, 388, 58, NULL, NULL),
(584, 389, 59, NULL, NULL),
(585, 389, 60, NULL, NULL),
(586, 390, 41, NULL, NULL),
(587, 390, 42, NULL, NULL),
(588, 392, 41, NULL, NULL),
(589, 392, 42, NULL, NULL),
(590, 394, 41, NULL, NULL),
(591, 394, 42, NULL, NULL),
(592, 396, 42, NULL, NULL),
(593, 398, 42, NULL, NULL),
(594, 401, 39, NULL, NULL),
(595, 401, 58, NULL, NULL),
(596, 401, 59, NULL, NULL),
(597, 402, 60, NULL, NULL),
(598, 402, 41, NULL, NULL),
(599, 402, 42, NULL, NULL),
(600, 403, 39, NULL, NULL),
(601, 403, 58, NULL, NULL),
(602, 403, 59, NULL, NULL),
(603, 404, 60, NULL, NULL),
(604, 404, 41, NULL, NULL),
(605, 404, 42, NULL, NULL),
(606, 405, 39, NULL, NULL),
(607, 405, 58, NULL, NULL),
(608, 405, 59, NULL, NULL),
(609, 406, 60, NULL, NULL),
(610, 406, 41, NULL, NULL),
(611, 406, 42, NULL, NULL),
(612, 407, 39, NULL, NULL),
(613, 407, 58, NULL, NULL),
(614, 407, 59, NULL, NULL),
(615, 408, 60, NULL, NULL),
(616, 408, 41, NULL, NULL),
(617, 408, 42, NULL, NULL),
(618, 409, 39, NULL, NULL),
(619, 409, 58, NULL, NULL),
(620, 409, 59, NULL, NULL),
(621, 410, 60, NULL, NULL),
(622, 410, 42, NULL, NULL),
(623, 422, 39, NULL, NULL),
(624, 422, 58, NULL, NULL),
(625, 422, 59, NULL, NULL),
(626, 423, 60, NULL, NULL),
(627, 423, 41, NULL, NULL),
(628, 423, 42, NULL, NULL),
(629, 424, 39, NULL, NULL),
(630, 424, 58, NULL, NULL),
(631, 424, 59, NULL, NULL),
(632, 425, 39, NULL, NULL),
(633, 425, 58, NULL, NULL),
(634, 425, 59, NULL, NULL),
(635, 426, 60, NULL, NULL),
(636, 426, 41, NULL, NULL),
(637, 426, 42, NULL, NULL),
(638, 427, 39, NULL, NULL),
(639, 427, 58, NULL, NULL),
(640, 427, 59, NULL, NULL),
(641, 428, 60, NULL, NULL),
(642, 428, 41, NULL, NULL),
(643, 428, 42, NULL, NULL),
(644, 429, 39, NULL, NULL),
(645, 429, 58, NULL, NULL),
(646, 429, 59, NULL, NULL),
(647, 430, 60, NULL, NULL),
(648, 430, 41, NULL, NULL),
(649, 430, 42, NULL, NULL),
(650, 431, 39, NULL, NULL),
(651, 431, 58, NULL, NULL),
(652, 431, 59, NULL, NULL),
(653, 432, 60, NULL, NULL),
(654, 432, 41, NULL, NULL),
(655, 432, 42, NULL, NULL),
(656, 433, 39, NULL, NULL),
(657, 433, 58, NULL, NULL),
(658, 433, 59, NULL, NULL),
(659, 434, 60, NULL, NULL),
(660, 434, 42, NULL, NULL),
(661, 440, 39, NULL, NULL),
(662, 440, 58, NULL, NULL),
(663, 440, 59, NULL, NULL),
(664, 441, 60, NULL, NULL),
(665, 441, 41, NULL, NULL),
(666, 441, 42, NULL, NULL),
(667, 442, 39, NULL, NULL),
(668, 442, 58, NULL, NULL),
(669, 442, 59, NULL, NULL),
(670, 443, 60, NULL, NULL),
(671, 443, 41, NULL, NULL),
(672, 443, 42, NULL, NULL),
(673, 444, 39, NULL, NULL),
(674, 444, 58, NULL, NULL),
(675, 444, 59, NULL, NULL),
(676, 445, 60, NULL, NULL),
(677, 445, 41, NULL, NULL),
(678, 445, 42, NULL, NULL),
(679, 446, 39, NULL, NULL),
(680, 446, 58, NULL, NULL),
(681, 446, 59, NULL, NULL),
(682, 447, 60, NULL, NULL),
(683, 447, 41, NULL, NULL),
(684, 447, 42, NULL, NULL),
(685, 448, 39, NULL, NULL),
(686, 448, 58, NULL, NULL),
(687, 448, 59, NULL, NULL),
(688, 449, 60, NULL, NULL),
(689, 449, 42, NULL, NULL),
(691, 455, 60, NULL, NULL),
(692, 456, 60, NULL, NULL),
(693, 457, 39, NULL, NULL),
(694, 458, 41, NULL, NULL),
(695, 459, 42, NULL, NULL),
(696, 460, 58, NULL, NULL),
(697, 461, 59, NULL, NULL);

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
(39, 'Juana', 'Chiommienti', 'jchiommienti1@mb.com', 'jchiommienti1@mb.com', 'test', 6),
(40, 'Farlay', 'Giamuzzo', 'fgiamuzzoj@mb.com', 'fgiamuzzoj@mb.com', 'test', 6),
(41, 'Ryan', 'Branham', 'rbranham@mb.com', 'rbranham@mb.com', 'test', 6),
(42, 'Ryan', 'Harris', 'rharris@mb.com', 'rharris@mb.com', 'test', 1),
(44, 'John', 'Doe', 'jdoe@mb.com', 'johdoe', 'pass', 2),
(47, 'John', 'Doe', 'jdoe1@mb.com', 'johdoe61', 'OYBVUJLN', 2),
(49, 'Johnny', 'Deep', 'jdeep@a.com', 'jdeep', '123', 4),
(50, 'Lisa', 'Felix', 'lfelix@mb.com', 'lfelix', 'AAA', 5),
(58, 'fdsfds', 'dsfds', 'sadsa@gg.vom', 'sadsa@gg.vom', 'HNOHCLRD', 6),
(59, 'dsafds', 'dsfasdf', 'd@s.com', 'd@s.com', 'FVLFVKCX', 6),
(60, 'fdsaasd', 'sadfasd', 'eee@g.com', 'eee@g.com', 'SIAFRQHO', 1),
(61, 'Charles', 'Potter', 'agav@mb.com', 'ablan', '123', 6);

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `ID` int(11) NOT NULL,
  `Name` text NOT NULL,
  `Department` int(11) NOT NULL,
  `CostPrice` decimal(11,0) NOT NULL,
  `SellingPrice` decimal(11,0) NOT NULL,
  `Length` decimal(10,0) NOT NULL,
  `Height` decimal(10,0) NOT NULL,
  `Width` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`ID`, `Name`, `Department`, `CostPrice`, `SellingPrice`, `Length`, `Height`, `Width`) VALUES
(2, 'Chair', 1, '10', '12', '1', '2', '3'),
(7, 'Headphones', 3, '50', '60', '2', '1', '3'),
(8, 'Drill', 3, '100', '120', '4', '4', '2'),
(9, 'Batteries', 3, '4', '5', '1', '1', '1'),
(10, 'Test1', 1, '299', '499', '3', '5', '4');

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
(2, 20, 5),
(7, 0, 70),
(8, 10, 1),
(9, 850, 80),
(10, 20, 10);

-- --------------------------------------------------------

--
-- Table structure for table `purchase`
--

CREATE TABLE `purchase` (
  `ID` int(11) NOT NULL,
  `Product` int(11) NOT NULL,
  `DateTime` datetime NOT NULL DEFAULT current_timestamp(),
  `Amount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `purchase`
--

INSERT INTO `purchase` (`ID`, `Product`, `DateTime`, `Amount`) VALUES
(1, 7, '2021-05-08 17:08:47', 2),
(2, 9, '2021-05-08 17:08:56', 5),
(3, 8, '2021-05-08 17:09:23', 3),
(4, 2, '2021-05-08 17:09:29', 1),
(5, 7, '2021-05-08 17:09:35', 5);

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
  `Date` datetime NOT NULL DEFAULT current_timestamp(),
  `Comment` text DEFAULT NULL,
  `Status` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `restock`
--

INSERT INTO `restock` (`ID`, `ItemID`, `AmountRequested`, `Date`, `Comment`, `Status`) VALUES
(2, 2, 10, '2021-05-05 10:42:34', 'Hello world!', 2),
(5, 2, 10, '2021-05-08 16:50:44', NULL, 2),
(10, 9, 100, '2021-05-09 12:59:21', 'a', 3),
(12, 9, 1000, '2021-05-11 11:41:40', NULL, 2),
(13, 8, 10, '2021-05-11 13:04:28', 'some reason', 3);

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
(72, 41, 6),
(73, 41, 7);

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
-- Table structure for table `sorting`
--

CREATE TABLE `sorting` (
  `Counter` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sorting`
--

INSERT INTO `sorting` (`Counter`) VALUES
(60);

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
(250, 1, '2021-05-27 07:00:00'),
(253, 1, '2021-05-28 07:00:00'),
(256, 1, '2021-05-29 07:00:00'),
(158, 1, '2021-06-11 07:00:00'),
(161, 1, '2021-06-12 07:00:00'),
(164, 1, '2021-06-13 07:00:00'),
(167, 1, '2021-06-14 07:00:00'),
(170, 1, '2021-06-15 07:00:00'),
(173, 1, '2021-06-16 07:00:00'),
(176, 1, '2021-06-17 07:00:00'),
(179, 1, '2021-06-18 07:00:00'),
(182, 1, '2021-06-19 07:00:00'),
(185, 1, '2021-06-20 07:00:00'),
(371, 1, '2021-06-21 07:00:00'),
(374, 1, '2021-06-22 07:00:00'),
(365, 1, '2021-06-23 07:00:00'),
(368, 1, '2021-06-24 07:00:00'),
(136, 1, '2021-06-27 07:00:00'),
(139, 1, '2021-06-28 07:00:00'),
(142, 1, '2021-06-29 07:00:00'),
(145, 1, '2021-06-30 07:00:00'),
(148, 1, '2021-07-01 07:00:00'),
(151, 1, '2021-07-02 07:00:00'),
(154, 1, '2021-07-03 07:00:00'),
(189, 1, '2021-07-11 07:00:00'),
(192, 1, '2021-07-12 07:00:00'),
(195, 1, '2021-07-13 07:00:00'),
(198, 1, '2021-07-14 07:00:00'),
(201, 1, '2021-07-15 07:00:00'),
(204, 1, '2021-07-16 07:00:00'),
(207, 1, '2021-07-17 07:00:00'),
(210, 1, '2021-07-18 07:00:00'),
(213, 1, '2021-07-19 07:00:00'),
(216, 1, '2021-07-20 07:00:00'),
(302, 1, '2021-07-26 07:00:00'),
(305, 1, '2021-07-27 07:00:00'),
(308, 1, '2021-07-28 07:00:00'),
(311, 1, '2021-07-29 07:00:00'),
(314, 1, '2021-07-30 07:00:00'),
(317, 1, '2021-07-31 07:00:00'),
(377, 1, '2021-08-01 07:00:00'),
(380, 1, '2021-08-02 07:00:00'),
(383, 1, '2021-08-03 07:00:00'),
(386, 1, '2021-08-04 07:00:00'),
(389, 1, '2021-08-05 07:00:00'),
(392, 1, '2021-08-06 07:00:00'),
(395, 1, '2021-08-07 07:00:00'),
(398, 1, '2021-08-08 07:00:00'),
(220, 1, '2021-08-11 07:00:00'),
(223, 1, '2021-08-12 07:00:00'),
(226, 1, '2021-08-13 07:00:00'),
(229, 1, '2021-08-14 07:00:00'),
(232, 1, '2021-08-15 07:00:00'),
(235, 1, '2021-08-16 07:00:00'),
(238, 1, '2021-08-17 07:00:00'),
(241, 1, '2021-08-18 07:00:00'),
(244, 1, '2021-08-19 07:00:00'),
(247, 1, '2021-08-20 07:00:00'),
(257, 1, '2021-09-16 07:00:00'),
(260, 1, '2021-09-17 07:00:00'),
(263, 1, '2021-09-18 07:00:00'),
(266, 1, '2021-09-19 07:00:00'),
(269, 1, '2021-09-20 07:00:00'),
(272, 1, '2021-09-21 07:00:00'),
(275, 1, '2021-09-22 07:00:00'),
(278, 1, '2021-09-23 07:00:00'),
(281, 1, '2021-09-24 07:00:00'),
(284, 1, '2021-09-25 07:00:00'),
(287, 1, '2021-09-26 07:00:00'),
(290, 1, '2021-09-27 07:00:00'),
(293, 1, '2021-09-28 07:00:00'),
(296, 1, '2021-09-29 07:00:00'),
(299, 1, '2021-09-30 07:00:00'),
(320, 1, '2021-10-01 07:00:00'),
(323, 1, '2021-10-02 07:00:00'),
(326, 1, '2021-10-03 07:00:00'),
(329, 1, '2021-10-04 07:00:00'),
(332, 1, '2021-10-05 07:00:00'),
(335, 1, '2021-10-06 07:00:00'),
(338, 1, '2021-10-07 07:00:00'),
(341, 1, '2021-10-08 07:00:00'),
(344, 1, '2021-10-09 07:00:00'),
(347, 1, '2021-10-10 07:00:00'),
(350, 1, '2021-10-11 07:00:00'),
(353, 1, '2021-10-12 07:00:00'),
(356, 1, '2021-10-13 07:00:00'),
(359, 1, '2021-10-14 07:00:00'),
(362, 1, '2021-10-15 07:00:00'),
(456, 1, '2021-11-08 07:00:00'),
(425, 1, '2021-12-01 07:00:00'),
(428, 1, '2021-12-02 07:00:00'),
(431, 1, '2021-12-03 07:00:00'),
(434, 1, '2021-12-04 07:00:00'),
(437, 1, '2021-12-05 07:00:00'),
(440, 1, '2021-12-06 07:00:00'),
(443, 1, '2021-12-07 07:00:00'),
(446, 1, '2021-12-08 07:00:00'),
(449, 1, '2021-12-09 07:00:00'),
(452, 1, '2021-12-10 07:00:00'),
(401, 1, '2021-12-20 07:00:00'),
(404, 1, '2021-12-21 07:00:00'),
(407, 1, '2021-12-22 07:00:00'),
(410, 1, '2021-12-23 07:00:00'),
(413, 1, '2021-12-24 07:00:00'),
(416, 1, '2021-12-25 07:00:00'),
(419, 1, '2021-12-26 07:00:00'),
(422, 1, '2021-12-27 07:00:00'),
(455, 1, '2022-06-16 07:00:00'),
(251, 2, '2021-05-27 15:00:00'),
(254, 2, '2021-05-28 15:00:00'),
(159, 2, '2021-06-11 15:00:00'),
(162, 2, '2021-06-12 15:00:00'),
(165, 2, '2021-06-13 15:00:00'),
(168, 2, '2021-06-14 15:00:00'),
(171, 2, '2021-06-15 15:00:00'),
(174, 2, '2021-06-16 15:00:00'),
(177, 2, '2021-06-17 15:00:00'),
(180, 2, '2021-06-18 15:00:00'),
(183, 2, '2021-06-19 15:00:00'),
(186, 2, '2021-06-20 15:00:00'),
(372, 2, '2021-06-21 15:00:00'),
(375, 2, '2021-06-22 15:00:00'),
(366, 2, '2021-06-23 15:00:00'),
(369, 2, '2021-06-24 15:00:00'),
(137, 2, '2021-06-27 15:00:00'),
(140, 2, '2021-06-28 15:00:00'),
(143, 2, '2021-06-29 15:00:00'),
(146, 2, '2021-06-30 15:00:00'),
(149, 2, '2021-07-01 15:00:00'),
(152, 2, '2021-07-02 15:00:00'),
(155, 2, '2021-07-03 15:00:00'),
(190, 2, '2021-07-11 15:00:00'),
(193, 2, '2021-07-12 15:00:00'),
(196, 2, '2021-07-13 15:00:00'),
(199, 2, '2021-07-14 15:00:00'),
(202, 2, '2021-07-15 15:00:00'),
(205, 2, '2021-07-16 15:00:00'),
(208, 2, '2021-07-17 15:00:00'),
(211, 2, '2021-07-18 15:00:00'),
(214, 2, '2021-07-19 15:00:00'),
(217, 2, '2021-07-20 15:00:00'),
(303, 2, '2021-07-26 15:00:00'),
(306, 2, '2021-07-27 15:00:00'),
(309, 2, '2021-07-28 15:00:00'),
(312, 2, '2021-07-29 15:00:00'),
(315, 2, '2021-07-30 15:00:00'),
(318, 2, '2021-07-31 15:00:00'),
(378, 2, '2021-08-01 15:00:00'),
(381, 2, '2021-08-02 15:00:00'),
(384, 2, '2021-08-03 15:00:00'),
(387, 2, '2021-08-04 15:00:00'),
(390, 2, '2021-08-05 15:00:00'),
(393, 2, '2021-08-06 15:00:00'),
(396, 2, '2021-08-07 15:00:00'),
(399, 2, '2021-08-08 15:00:00'),
(221, 2, '2021-08-11 15:00:00'),
(224, 2, '2021-08-12 15:00:00'),
(227, 2, '2021-08-13 15:00:00'),
(230, 2, '2021-08-14 15:00:00'),
(233, 2, '2021-08-15 15:00:00'),
(236, 2, '2021-08-16 15:00:00'),
(239, 2, '2021-08-17 15:00:00'),
(242, 2, '2021-08-18 15:00:00'),
(245, 2, '2021-08-19 15:00:00'),
(248, 2, '2021-08-20 15:00:00'),
(258, 2, '2021-09-16 15:00:00'),
(261, 2, '2021-09-17 15:00:00'),
(264, 2, '2021-09-18 15:00:00'),
(267, 2, '2021-09-19 15:00:00'),
(270, 2, '2021-09-20 15:00:00'),
(273, 2, '2021-09-21 15:00:00'),
(276, 2, '2021-09-22 15:00:00'),
(279, 2, '2021-09-23 15:00:00'),
(282, 2, '2021-09-24 15:00:00'),
(285, 2, '2021-09-25 15:00:00'),
(288, 2, '2021-09-26 15:00:00'),
(291, 2, '2021-09-27 15:00:00'),
(294, 2, '2021-09-28 15:00:00'),
(297, 2, '2021-09-29 15:00:00'),
(300, 2, '2021-09-30 15:00:00'),
(321, 2, '2021-10-01 15:00:00'),
(324, 2, '2021-10-02 15:00:00'),
(327, 2, '2021-10-03 15:00:00'),
(330, 2, '2021-10-04 15:00:00'),
(333, 2, '2021-10-05 15:00:00'),
(336, 2, '2021-10-06 15:00:00'),
(339, 2, '2021-10-07 15:00:00'),
(342, 2, '2021-10-08 15:00:00'),
(345, 2, '2021-10-09 15:00:00'),
(348, 2, '2021-10-10 15:00:00'),
(351, 2, '2021-10-11 15:00:00'),
(354, 2, '2021-10-12 15:00:00'),
(357, 2, '2021-10-13 15:00:00'),
(360, 2, '2021-10-14 15:00:00'),
(363, 2, '2021-10-15 15:00:00'),
(458, 2, '2021-11-09 15:00:00'),
(426, 2, '2021-12-01 15:00:00'),
(429, 2, '2021-12-02 15:00:00'),
(432, 2, '2021-12-03 15:00:00'),
(435, 2, '2021-12-04 15:00:00'),
(438, 2, '2021-12-05 15:00:00'),
(441, 2, '2021-12-06 15:00:00'),
(444, 2, '2021-12-07 15:00:00'),
(447, 2, '2021-12-08 15:00:00'),
(450, 2, '2021-12-09 15:00:00'),
(453, 2, '2021-12-10 15:00:00'),
(459, 2, '2021-12-18 15:00:00'),
(460, 2, '2021-12-19 15:00:00'),
(402, 2, '2021-12-20 15:00:00'),
(405, 2, '2021-12-21 15:00:00'),
(408, 2, '2021-12-22 15:00:00'),
(411, 2, '2021-12-23 15:00:00'),
(414, 2, '2021-12-24 15:00:00'),
(417, 2, '2021-12-25 15:00:00'),
(420, 2, '2021-12-26 15:00:00'),
(423, 2, '2021-12-27 15:00:00'),
(461, 2, '2022-02-09 15:00:00'),
(252, 3, '2021-05-27 23:00:00'),
(255, 3, '2021-05-28 23:00:00'),
(157, 3, '2021-06-10 23:00:00'),
(160, 3, '2021-06-11 23:00:00'),
(163, 3, '2021-06-12 23:00:00'),
(166, 3, '2021-06-13 23:00:00'),
(169, 3, '2021-06-14 23:00:00'),
(172, 3, '2021-06-15 23:00:00'),
(175, 3, '2021-06-16 23:00:00'),
(178, 3, '2021-06-17 23:00:00'),
(181, 3, '2021-06-18 23:00:00'),
(184, 3, '2021-06-19 23:00:00'),
(187, 3, '2021-06-20 23:00:00'),
(373, 3, '2021-06-21 23:00:00'),
(376, 3, '2021-06-22 23:00:00'),
(367, 3, '2021-06-23 23:00:00'),
(370, 3, '2021-06-24 23:00:00'),
(135, 3, '2021-06-26 23:00:00'),
(138, 3, '2021-06-27 23:00:00'),
(141, 3, '2021-06-28 23:00:00'),
(144, 3, '2021-06-29 23:00:00'),
(147, 3, '2021-06-30 23:00:00'),
(150, 3, '2021-07-01 23:00:00'),
(153, 3, '2021-07-02 23:00:00'),
(156, 3, '2021-07-03 23:00:00'),
(188, 3, '2021-07-10 23:00:00'),
(191, 3, '2021-07-11 23:00:00'),
(194, 3, '2021-07-12 23:00:00'),
(197, 3, '2021-07-13 23:00:00'),
(200, 3, '2021-07-14 23:00:00'),
(203, 3, '2021-07-15 23:00:00'),
(206, 3, '2021-07-16 23:00:00'),
(209, 3, '2021-07-17 23:00:00'),
(212, 3, '2021-07-18 23:00:00'),
(215, 3, '2021-07-19 23:00:00'),
(218, 3, '2021-07-20 23:00:00'),
(304, 3, '2021-07-26 23:00:00'),
(307, 3, '2021-07-27 23:00:00'),
(310, 3, '2021-07-28 23:00:00'),
(313, 3, '2021-07-29 23:00:00'),
(316, 3, '2021-07-30 23:00:00'),
(319, 3, '2021-07-31 23:00:00'),
(379, 3, '2021-08-01 23:00:00'),
(382, 3, '2021-08-02 23:00:00'),
(385, 3, '2021-08-03 23:00:00'),
(388, 3, '2021-08-04 23:00:00'),
(391, 3, '2021-08-05 23:00:00'),
(394, 3, '2021-08-06 23:00:00'),
(397, 3, '2021-08-07 23:00:00'),
(400, 3, '2021-08-08 23:00:00'),
(219, 3, '2021-08-10 23:00:00'),
(222, 3, '2021-08-11 23:00:00'),
(225, 3, '2021-08-12 23:00:00'),
(228, 3, '2021-08-13 23:00:00'),
(231, 3, '2021-08-14 23:00:00'),
(234, 3, '2021-08-15 23:00:00'),
(237, 3, '2021-08-16 23:00:00'),
(240, 3, '2021-08-17 23:00:00'),
(243, 3, '2021-08-18 23:00:00'),
(246, 3, '2021-08-19 23:00:00'),
(249, 3, '2021-08-20 23:00:00'),
(259, 3, '2021-09-16 23:00:00'),
(262, 3, '2021-09-17 23:00:00'),
(265, 3, '2021-09-18 23:00:00'),
(268, 3, '2021-09-19 23:00:00'),
(271, 3, '2021-09-20 23:00:00'),
(274, 3, '2021-09-21 23:00:00'),
(277, 3, '2021-09-22 23:00:00'),
(280, 3, '2021-09-23 23:00:00'),
(283, 3, '2021-09-24 23:00:00'),
(286, 3, '2021-09-25 23:00:00'),
(289, 3, '2021-09-26 23:00:00'),
(292, 3, '2021-09-27 23:00:00'),
(295, 3, '2021-09-28 23:00:00'),
(298, 3, '2021-09-29 23:00:00'),
(301, 3, '2021-09-30 23:00:00'),
(322, 3, '2021-10-01 23:00:00'),
(325, 3, '2021-10-02 23:00:00'),
(328, 3, '2021-10-03 23:00:00'),
(331, 3, '2021-10-04 23:00:00'),
(334, 3, '2021-10-05 23:00:00'),
(337, 3, '2021-10-06 23:00:00'),
(340, 3, '2021-10-07 23:00:00'),
(343, 3, '2021-10-08 23:00:00'),
(346, 3, '2021-10-09 23:00:00'),
(349, 3, '2021-10-10 23:00:00'),
(352, 3, '2021-10-11 23:00:00'),
(355, 3, '2021-10-12 23:00:00'),
(358, 3, '2021-10-13 23:00:00'),
(361, 3, '2021-10-14 23:00:00'),
(364, 3, '2021-10-15 23:00:00'),
(457, 3, '2021-11-08 23:00:00'),
(427, 3, '2021-12-01 23:00:00'),
(430, 3, '2021-12-02 23:00:00'),
(433, 3, '2021-12-03 23:00:00'),
(436, 3, '2021-12-04 23:00:00'),
(439, 3, '2021-12-05 23:00:00'),
(442, 3, '2021-12-06 23:00:00'),
(445, 3, '2021-12-07 23:00:00'),
(448, 3, '2021-12-08 23:00:00'),
(451, 3, '2021-12-09 23:00:00'),
(454, 3, '2021-12-10 23:00:00'),
(403, 3, '2021-12-20 23:00:00'),
(406, 3, '2021-12-21 23:00:00'),
(409, 3, '2021-12-22 23:00:00'),
(412, 3, '2021-12-23 23:00:00'),
(415, 3, '2021-12-24 23:00:00'),
(418, 3, '2021-12-25 23:00:00'),
(421, 3, '2021-12-26 23:00:00'),
(424, 3, '2021-12-27 23:00:00');

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
  ADD UNIQUE KEY `Name` (`Name`),
  ADD KEY `Manager` (`Manager`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD UNIQUE KEY `ID` (`ID`),
  ADD KEY `DepartmentID` (`DepartmentID`),
  ADD KEY `ContractID` (`ContractID`),
  ADD KEY `Status` (`Status`),
  ADD KEY `IsDepManager` (`IsDepManager`);

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
-- Indexes for table `purchase`
--
ALTER TABLE `purchase`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Product` (`Product`);

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
  ADD KEY `ItemID` (`ItemID`),
  ADD KEY `Status` (`Status`);

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
-- Indexes for table `sorting`
--
ALTER TABLE `sorting`
  ADD KEY `Counter` (`Counter`);

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
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

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
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `employeeassignment`
--
ALTER TABLE `employeeassignment`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=698;

--
-- AUTO_INCREMENT for table `employeestatus`
--
ALTER TABLE `employeestatus`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `person`
--
ALTER TABLE `person`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=62;

--
-- AUTO_INCREMENT for table `product`
--
ALTER TABLE `product`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `purchase`
--
ALTER TABLE `purchase`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `requeststatus`
--
ALTER TABLE `requeststatus`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `restock`
--
ALTER TABLE `restock`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `shiftpreference`
--
ALTER TABLE `shiftpreference`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=74;

--
-- AUTO_INCREMENT for table `shifttime`
--
ALTER TABLE `shifttime`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `workshift`
--
ALTER TABLE `workshift`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=462;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `contactmessages`
--
ALTER TABLE `contactmessages`
  ADD CONSTRAINT `contactmessages_ibfk_1` FOREIGN KEY (`Sender`) REFERENCES `person` (`ID`);

--
-- Constraints for table `department`
--
ALTER TABLE `department`
  ADD CONSTRAINT `department_ibfk_1` FOREIGN KEY (`Manager`) REFERENCES `person` (`ID`);

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
-- Constraints for table `purchase`
--
ALTER TABLE `purchase`
  ADD CONSTRAINT `purchase_ibfk_1` FOREIGN KEY (`Product`) REFERENCES `product` (`ID`);

--
-- Constraints for table `restock`
--
ALTER TABLE `restock`
  ADD CONSTRAINT `restock_ibfk_1` FOREIGN KEY (`ItemID`) REFERENCES `product` (`ID`),
  ADD CONSTRAINT `restock_ibfk_2` FOREIGN KEY (`Status`) REFERENCES `requeststatus` (`ID`);

--
-- Constraints for table `shiftpreference`
--
ALTER TABLE `shiftpreference`
  ADD CONSTRAINT `shiftpreference_ibfk_1` FOREIGN KEY (`Employee`) REFERENCES `employee` (`ID`),
  ADD CONSTRAINT `shiftpreference_ibfk_2` FOREIGN KEY (`Day`) REFERENCES `weekday` (`ID`);

--
-- Constraints for table `sorting`
--
ALTER TABLE `sorting`
  ADD CONSTRAINT `sorting_ibfk_1` FOREIGN KEY (`Counter`) REFERENCES `employee` (`ID`);

--
-- Constraints for table `workshift`
--
ALTER TABLE `workshift`
  ADD CONSTRAINT `workshift_ibfk_1` FOREIGN KEY (`ShiftType`) REFERENCES `shifttime` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
