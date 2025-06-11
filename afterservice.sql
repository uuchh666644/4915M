-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 06, 2025 at 06:15 AM
-- Server version: 10.1.30-MariaDB
-- PHP Version: 5.6.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `afterservice`
--

-- --------------------------------------------------------

--
-- Table structure for table `info`
--

CREATE TABLE `info` (
  `RequestID` int(20) NOT NULL,
  `OrderID` int(20) NOT NULL,
  `OrderDate` varchar(50) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Phone` varchar(20) NOT NULL,
  `Request` varchar(100) NOT NULL,
  `state` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `info`
--

INSERT INTO `info` (`RequestID`, `OrderID`, `OrderDate`, `Name`, `Email`, `Phone`, `Request`, `state`) VALUES
(1, 2025111, '12-Jun-25 13:30:08', 'Kenny', 'kenny@gmail.com', '56987821', 'exchange', 'exchanged'),
(2, 1235, '04-Jun-25 11:00:17', 'bobby', 'dasds@gmail.com', '98321456', 'exchange', 'Disapprove(over 2 weeks)'),
(3, 45646465, '01-May-25 11:02:09', 'jimmy', 'jimmy@gmail.com', '45879632', 'exchange', 'exchanged'),
(6, 456465, '12-Jun-25 13:30:08', 'jim', 'dsadsa@gmail.com', '89563214', 'refund', 'Refunded'),
(7, 65465478, '05-Jun-25 14:53:49', 'Bobby', 'dsadsa@gmail.com', '97846531', 'refund', 'Waiting for approval'),
(8, 432432, '5/6/2025 17:54:04', 'jimmy', 'jimmy@gmail.com', '78432132', 'Refund', 'Refunded');

-- --------------------------------------------------------

--
-- Table structure for table `inwardrecord`
--

CREATE TABLE `inwardrecord` (
  `Dateti` varchar(50) NOT NULL,
  `ItemName` text NOT NULL,
  `Quantity` int(11) NOT NULL,
  `Supplier` text NOT NULL,
  `price` float NOT NULL,
  `inID` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `makeorder`
--

CREATE TABLE `makeorder` (
  `orderID` int(20) NOT NULL,
  `guestname` varchar(50) NOT NULL,
  `product` varchar(200) NOT NULL,
  `phone` int(11) NOT NULL,
  `address` varchar(200) NOT NULL,
  `email` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `makeorder`
--

INSERT INTO `makeorder` (`orderID`, `guestname`, `product`, `phone`, `address`, `email`) VALUES
(2, 'dsadsadsa', 'Tony', 342432, 'sads', 'dsad');

-- --------------------------------------------------------

--
-- Table structure for table `productinventry`
--

CREATE TABLE `productinventry` (
  `prodname` text NOT NULL,
  `prodID` int(11) NOT NULL,
  `Quantity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `requirements`
--

CREATE TABLE `requirements` (
  `ReqId` varchar(36) NOT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `ReceivingTime` datetime DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  `productType` varchar(20) DEFAULT NULL,
  `CreateTime` datetime DEFAULT CURRENT_TIMESTAMP,
  `cusName` varchar(50) NOT NULL,
  `cusPhone` int(11) NOT NULL,
  `cusAddress` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `requirements`
--

INSERT INTO `requirements` (`ReqId`, `CreatedBy`, `ReceivingTime`, `remark`, `productType`, `CreateTime`, `cusName`, `cusPhone`, `cusAddress`) VALUES
('A32E0E98', 'fsfsddd', '2025-06-05 00:00:00', 'ddfd', 'fsfxcc', '2025-06-05 20:37:49', '', 0, ''),
('B268D49F', 'ff', '2025-06-05 00:00:00', 'cscvsv', 'svadf', '2025-06-05 20:41:39', '', 0, ''),
('C869A0F7', 'create', '2025-06-05 00:00:00', 'product', 'remark', '2025-06-05 20:51:14', '', 0, '');

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

CREATE TABLE `supplier` (
  `suppliername` text NOT NULL,
  `phonenumber` int(11) NOT NULL,
  `country` text NOT NULL,
  `supplieremail` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `userid` int(30) NOT NULL,
  `username` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL,
  `permission` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`userid`, `username`, `password`, `permission`) VALUES
(1, 'au-yeungyingkit', 'A456892', 'inventory staff'),
(2, 'nghoyin', 'O89556412', 'delivery staff'),
(3, 'wangchunho', 'L78921', 'product controller staff'),
(4, 'tsepokchuen', 'U4568731', 'Manager');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `info`
--
ALTER TABLE `info`
  ADD PRIMARY KEY (`RequestID`);

--
-- Indexes for table `inwardrecord`
--
ALTER TABLE `inwardrecord`
  ADD PRIMARY KEY (`inID`);

--
-- Indexes for table `makeorder`
--
ALTER TABLE `makeorder`
  ADD PRIMARY KEY (`orderID`);

--
-- Indexes for table `requirements`
--
ALTER TABLE `requirements`
  ADD PRIMARY KEY (`ReqId`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`userid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `info`
--
ALTER TABLE `info`
  MODIFY `RequestID` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `inwardrecord`
--
ALTER TABLE `inwardrecord`
  MODIFY `inID` int(5) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `makeorder`
--
ALTER TABLE `makeorder`
  MODIFY `orderID` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `userid` int(30) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
