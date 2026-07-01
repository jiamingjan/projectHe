-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: 47.105.62.139    Database: vueworkdb
-- ------------------------------------------------------
-- Server version	8.0.21

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
-- Table structure for table `casbin_rule`
--

DROP TABLE IF EXISTS `casbin_rule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `casbin_rule` (
  `ptype` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `v0` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `v1` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `v2` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `v3` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `v4` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `v5` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `id` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`),
  UNIQUE KEY `idx_casbin_rule` (`ptype`,`v0`,`v1`,`v2`,`v3`,`v4`,`v5`)
) ENGINE=InnoDB AUTO_INCREMENT=856 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `casbin_rule`
--

LOCK TABLES `casbin_rule` WRITE;
/*!40000 ALTER TABLE `casbin_rule` DISABLE KEYS */;
INSERT INTO `casbin_rule` VALUES ('p','admin','/system/api','POST',NULL,NULL,NULL,835),('p','admin','/system/api','PUT',NULL,NULL,NULL,836),('p','admin','/system/api/:id','DELETE',NULL,NULL,NULL,837),('p','admin','/system/api/:id','GET',NULL,NULL,NULL,834),('p','admin','/system/api/all','GET',NULL,NULL,NULL,832),('p','admin','/system/api/getPolicyPathByRoleId','GET',NULL,NULL,NULL,833),('p','admin','/system/api/list','GET',NULL,NULL,NULL,831),('p','admin','/system/config','POST',NULL,NULL,NULL,794),('p','admin','/system/config','PUT',NULL,NULL,NULL,795),('p','admin','/system/config/:configId','DELETE',NULL,NULL,NULL,796),('p','admin','/system/config/:configId','GET',NULL,NULL,NULL,793),('p','admin','/system/config/configKey','GET',NULL,NULL,NULL,792),('p','admin','/system/config/list','GET',NULL,NULL,NULL,791),('p','admin','/system/dept','POST',NULL,NULL,NULL,788),('p','admin','/system/dept','PUT',NULL,NULL,NULL,789),('p','admin','/system/dept/:deptId','DELETE',NULL,NULL,NULL,790),('p','admin','/system/dept/:deptId','GET',NULL,NULL,NULL,785),('p','admin','/system/dept/deptTree','GET',NULL,NULL,NULL,787),('p','admin','/system/dept/list','GET',NULL,NULL,NULL,784),('p','admin','/system/dept/roleDeptTreeSelect/:roleId','GET',NULL,NULL,NULL,786),('p','admin','/system/dict/data','POST',NULL,NULL,NULL,806),('p','admin','/system/dict/data','PUT',NULL,NULL,NULL,807),('p','admin','/system/dict/data/:dictCode','DELETE',NULL,NULL,NULL,808),('p','admin','/system/dict/data/:dictCode','GET',NULL,NULL,NULL,805),('p','admin','/system/dict/data/list','GET',NULL,NULL,NULL,803),('p','admin','/system/dict/data/type','GET',NULL,NULL,NULL,804),('p','admin','/system/dict/type','POST',NULL,NULL,NULL,799),('p','admin','/system/dict/type','PUT',NULL,NULL,NULL,800),('p','admin','/system/dict/type/:dictId','DELETE',NULL,NULL,NULL,801),('p','admin','/system/dict/type/:dictId','GET',NULL,NULL,NULL,798),('p','admin','/system/dict/type/export','GET',NULL,NULL,NULL,802),('p','admin','/system/dict/type/list','GET',NULL,NULL,NULL,797),('p','admin','/system/menu','POST',NULL,NULL,NULL,815),('p','admin','/system/menu','PUT',NULL,NULL,NULL,816),('p','admin','/system/menu/:menuId','DELETE',NULL,NULL,NULL,817),('p','admin','/system/menu/:menuId','GET',NULL,NULL,NULL,814),('p','admin','/system/menu/list','GET',NULL,NULL,NULL,813),('p','admin','/system/menu/menuPaths','GET',NULL,NULL,NULL,812),('p','admin','/system/menu/menuRole','GET',NULL,NULL,NULL,810),('p','admin','/system/menu/menuTreeSelect','GET',NULL,NULL,NULL,809),('p','admin','/system/menu/roleMenuTreeSelect/:roleId','GET',NULL,NULL,NULL,811),('p','admin','/system/post','POST',NULL,NULL,NULL,820),('p','admin','/system/post','PUT',NULL,NULL,NULL,821),('p','admin','/system/post/:postId','DELETE',NULL,NULL,NULL,822),('p','admin','/system/post/:postId','GET',NULL,NULL,NULL,819),('p','admin','/system/post/list','GET',NULL,NULL,NULL,818),('p','admin','/system/role','POST',NULL,NULL,NULL,825),('p','admin','/system/role','PUT',NULL,NULL,NULL,826),('p','admin','/system/role/:roleId','DELETE',NULL,NULL,NULL,827),('p','admin','/system/role/:roleId','GET',NULL,NULL,NULL,824),('p','admin','/system/role/changeStatus','PUT',NULL,NULL,NULL,828),('p','admin','/system/role/dataScope','PUT',NULL,NULL,NULL,829),('p','admin','/system/role/export','GET',NULL,NULL,NULL,830),('p','admin','/system/role/list','GET',NULL,NULL,NULL,823),('p','admin','/system/user','POST',NULL,NULL,NULL,781),('p','admin','/system/user','PUT',NULL,NULL,NULL,782),('p','admin','/system/user/:userId','DELETE',NULL,NULL,NULL,775),('p','admin','/system/user/avatar','POST',NULL,NULL,NULL,776),('p','admin','/system/user/changeStatus','PUT',NULL,NULL,NULL,774),('p','admin','/system/user/export','GET',NULL,NULL,NULL,783),('p','admin','/system/user/getById/:userId','GET',NULL,NULL,NULL,778),('p','admin','/system/user/getInit','GET',NULL,NULL,NULL,779),('p','admin','/system/user/getRoPo','GET',NULL,NULL,NULL,780),('p','admin','/system/user/list','GET',NULL,NULL,NULL,773),('p','admin','/system/user/pwd','PUT',NULL,NULL,NULL,777),('p','guest','/system/dept','POST',NULL,NULL,NULL,853),('p','guest','/system/dept','PUT',NULL,NULL,NULL,854),('p','guest','/system/dept/:deptId','DELETE',NULL,NULL,NULL,855),('p','guest','/system/dept/:deptId','GET',NULL,NULL,NULL,850),('p','guest','/system/dept/deptTree','GET',NULL,NULL,NULL,852),('p','guest','/system/dept/list','GET',NULL,NULL,NULL,849),('p','guest','/system/dept/roleDeptTreeSelect/:roleId','GET',NULL,NULL,NULL,851),('p','guest','/system/user','POST',NULL,NULL,NULL,846),('p','guest','/system/user','PUT',NULL,NULL,NULL,847),('p','guest','/system/user/:userId','DELETE',NULL,NULL,NULL,840),('p','guest','/system/user/avatar','POST',NULL,NULL,NULL,841),('p','guest','/system/user/changeStatus','PUT',NULL,NULL,NULL,839),('p','guest','/system/user/export','GET',NULL,NULL,NULL,848),('p','guest','/system/user/getById/:userId','GET',NULL,NULL,NULL,843),('p','guest','/system/user/getInit','GET',NULL,NULL,NULL,844),('p','guest','/system/user/getRoPo','GET',NULL,NULL,NULL,845),('p','guest','/system/user/list','GET',NULL,NULL,NULL,838),('p','guest','/system/user/pwd','PUT',NULL,NULL,NULL,842);
/*!40000 ALTER TABLE `casbin_rule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `falldown_device`
--

DROP TABLE IF EXISTS `falldown_device`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `falldown_device` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `DeviceCode` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Status` varchar(1) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '状态',
  `Model` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '型号',
  `ContactPhones` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '家属电话',
  `Phone` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '电话',
  `Flag` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '删除标识',
  `CreateBy` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `UpdateBy` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `CreateTime` datetime DEFAULT NULL,
  `UpdateTime` datetime DEFAULT NULL,
  `DeleteTime` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `falldown_device`
--

LOCK TABLES `falldown_device` WRITE;
/*!40000 ALTER TABLE `falldown_device` DISABLE KEYS */;
INSERT INTO `falldown_device` VALUES (1,'01x3454','0','fad-tec20214','13812345678','138123443478',NULL,NULL,'','hello4我们的',NULL,'2021-12-30 22:56:00',NULL);
/*!40000 ALTER TABLE `falldown_device` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `falldown_location`
--

DROP TABLE IF EXISTS `falldown_location`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `falldown_location` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `DeviceCode` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Status` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '状态',
  `Lon` decimal(12,7) DEFAULT NULL COMMENT '经度',
  `Lat` decimal(12,7) DEFAULT NULL COMMENT '纬度',
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `UpdateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `falldown_location`
--

LOCK TABLES `falldown_location` WRITE;
/*!40000 ALTER TABLE `falldown_location` DISABLE KEYS */;
INSERT INTO `falldown_location` VALUES (3,'abc1',NULL,120.3535700,30.3230600,NULL,NULL),(4,'abc1',NULL,120.3544340,30.3230600,NULL,NULL),(5,'abc1',NULL,120.3547990,30.3238310,NULL,NULL),(6,'abc1',NULL,120.3591979,30.3236040,NULL,NULL),(7,'abc1',NULL,120.3613705,30.3231503,NULL,NULL),(8,'abc1',NULL,120.3618157,30.3234140,NULL,NULL),(9,'abc1',NULL,120.3617620,30.3244561,NULL,NULL);
/*!40000 ALTER TABLE `falldown_location` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `log_logins`
--

DROP TABLE IF EXISTS `log_logins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `log_logins` (
  `info_id` bigint NOT NULL AUTO_INCREMENT,
  `username` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '用户名',
  `status` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '状态',
  `ipaddr` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'ip地址',
  `login_location` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '归属地',
  `browser` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '浏览器',
  `os` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '系统',
  `platform` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '固件',
  `login_time` timestamp NULL DEFAULT NULL COMMENT '登录时间',
  `create_by` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '创建人',
  `update_by` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '更新者',
  `remark` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `msg` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `create_time` datetime DEFAULT NULL,
  `update_time` datetime DEFAULT NULL,
  `delete_time` datetime DEFAULT NULL,
  PRIMARY KEY (`info_id`)
) ENGINE=InnoDB AUTO_INCREMENT=154 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `log_logins`
--

LOCK TABLES `log_logins` WRITE;
/*!40000 ALTER TABLE `log_logins` DISABLE KEYS */;
INSERT INTO `log_logins` VALUES (153,'admin',NULL,'127.0.0.1','abc','ad',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `log_logins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `log_opers`
--

DROP TABLE IF EXISTS `log_opers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `log_opers` (
  `oper_id` bigint NOT NULL AUTO_INCREMENT,
  `title` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '操作的模块',
  `business_type` int DEFAULT NULL COMMENT '0其它 1新增 2修改 3删除',
  `method` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '请求方法',
  `oper_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '操作人员',
  `oper_url` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '操作url',
  `oper_ip` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '操作IP',
  `oper_location` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '操作地点',
  `oper_param` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '请求参数',
  `status` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '0=正常,1=异常',
  `create_time` datetime DEFAULT NULL,
  `update_time` datetime DEFAULT NULL,
  `delete_time` datetime DEFAULT NULL,
  PRIMARY KEY (`oper_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `log_opers`
--

LOCK TABLES `log_opers` WRITE;
/*!40000 ALTER TABLE `log_opers` DISABLE KEYS */;
/*!40000 ALTER TABLE `log_opers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `research_paper`
--

DROP TABLE IF EXISTS `research_paper`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `research_paper` (
  `paperId` int unsigned NOT NULL AUTO_INCREMENT,
  `PaperModel` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `PaperAuthor` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `PaperCode` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `CreateBy` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `UpdateBy` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `CreateTime` datetime DEFAULT NULL,
  `UpdateTime` datetime DEFAULT NULL,
  `DeleteTime` datetime DEFAULT NULL,
  PRIMARY KEY (`paperId`),
  UNIQUE KEY `paperId_UNIQUE` (`paperId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `research_paper`
--

LOCK TABLES `research_paper` WRITE;
/*!40000 ALTER TABLE `research_paper` DISABLE KEYS */;
/*!40000 ALTER TABLE `research_paper` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_apis`
--

DROP TABLE IF EXISTS `sys_apis`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_apis` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `create_time` datetime DEFAULT NULL,
  `update_time` datetime DEFAULT NULL,
  `delete_time` datetime DEFAULT NULL,
  `path` varchar(191) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'api路径',
  `description` varchar(191) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'api中文描述',
  `api_group` varchar(191) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'api组',
  `method` varchar(191) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '方法',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=66 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_apis`
--

LOCK TABLES `sys_apis` WRITE;
/*!40000 ALTER TABLE `sys_apis` DISABLE KEYS */;
INSERT INTO `sys_apis` VALUES (1,'2021-12-09 09:21:04','2021-12-09 09:21:04',NULL,'/system/user/list','查询用户列表（分页）','user','GET'),(2,'2021-12-09 09:29:36','2021-12-09 09:29:36',NULL,'/system/user/changeStatus','修改用户状态','user','PUT'),(3,'2021-12-09 09:34:37','2021-12-09 09:34:37',NULL,'/system/user/:userId','删除用户信息','user','DELETE'),(4,'2021-12-09 09:36:43','2021-12-09 09:36:43',NULL,'/system/dept/list','获取部门列表','dept','GET'),(5,'2021-12-09 09:37:31','2021-12-09 09:37:31',NULL,'/system/dept/:deptId','获取部门信息','dept','GET'),(6,'2021-12-09 18:20:32','2021-12-09 18:20:32',NULL,'/system/user/avatar','上传头像','user','POST'),(7,'2021-12-09 18:21:10','2021-12-09 18:21:10',NULL,'/system/user/pwd','修改密码','user','PUT'),(8,'2021-12-09 18:21:54','2021-12-09 18:21:54',NULL,'/system/user/getById/:userId','通过id获取用户信息','user','GET'),(9,'2021-12-09 18:58:50','2021-12-09 18:58:50',NULL,'/system/user/getInit','获取初始化角色岗位信息(添加用户初始化)','user','GET'),(10,'2021-12-09 18:59:43','2021-12-09 18:59:43',NULL,'/system/user/getRoPo','获取用户角色岗位信息','user','GET'),(11,'2021-12-09 19:00:24','2021-12-09 19:00:24',NULL,'/system/user','添加用户信息','user','POST'),(12,'2021-12-09 19:00:52','2021-12-09 19:00:52',NULL,'/system/user','修改用户信息','user','PUT'),(13,'2021-12-09 19:02:30','2021-12-09 19:02:30',NULL,'/system/user/export','导出用户信息','user','GET'),(14,'2021-12-09 19:04:04','2021-12-09 19:04:04',NULL,'/system/dept/roleDeptTreeSelect/:roleId','获取角色部门树','dept','GET'),(15,'2021-12-09 19:04:48','2021-12-09 19:04:48',NULL,'/system/dept/deptTree','获取所有部门树','dept','GET'),(16,'2021-12-09 19:07:37','2021-12-09 19:07:37',NULL,'/system/dept','添加部门信息','dept','POST'),(17,'2021-12-09 19:08:14','2021-12-09 19:08:14',NULL,'/system/dept','修改部门信息','dept','PUT'),(18,'2021-12-09 19:08:40','2021-12-09 19:08:40',NULL,'/system/dept/:deptId','删除部门信息','dept','DELETE'),(19,'2021-12-09 19:09:41','2021-12-09 19:09:41',NULL,'/system/config/list','获取配置分页列表','config','GET'),(20,'2021-12-09 19:10:11','2021-12-09 19:10:11',NULL,'/system/config/configKey','获取配置列表通过ConfigKey','config','GET'),(21,'2021-12-09 19:10:45','2021-12-09 19:10:45',NULL,'/system/config/:configId','获取配置信息','config','GET'),(22,'2021-12-09 19:11:22','2021-12-09 19:11:22',NULL,'/system/config','添加配置信息','config','POST'),(23,'2021-12-09 19:11:41','2021-12-09 19:11:41',NULL,'/system/config','修改配置信息','config','PUT'),(24,'2021-12-09 19:12:28','2021-12-09 19:12:28',NULL,'/system/config/:configId','删除配置信息','config','DELETE'),(25,'2021-12-09 19:13:08','2021-12-09 19:13:08',NULL,'/system/dict/type/list','获取字典类型分页列表','dict','GET'),(26,'2021-12-09 19:13:55','2021-12-09 19:13:55',NULL,'/system/dict/type/:dictId','获取字典类型信息','dict','GET'),(27,'2021-12-09 19:14:28','2021-12-09 19:14:28',NULL,'/system/dict/type','添加字典类型信息','dict','POST'),(28,'2021-12-09 19:14:55','2021-12-09 19:14:55',NULL,'/system/dict/type','修改字典类型信息','dict','PUT'),(29,'2021-12-09 19:15:17','2021-12-09 19:15:17',NULL,'/system/dict/type/:dictId','删除字典类型信息','dict','DELETE'),(30,'2021-12-09 19:15:50','2021-12-09 19:15:50',NULL,'/system/dict/type/export','导出字典类型信息','dict','GET'),(31,'2021-12-09 19:16:26','2021-12-09 19:16:26',NULL,'/system/dict/data/list','获取字典数据分页列表','dict','GET'),(32,'2021-12-09 19:17:01','2021-12-09 19:17:01',NULL,'/system/dict/data/type','获取字典数据列表通过字典类型','dict','GET'),(33,'2021-12-09 19:17:39','2021-12-09 19:17:39',NULL,'/system/dict/data/:dictCode','获取字典数据信息','dict','GET'),(34,'2021-12-09 19:18:20','2021-12-09 19:18:20',NULL,'/system/dict/data','添加字典数据信息','dict','POST'),(35,'2021-12-09 19:18:44','2021-12-09 19:18:44',NULL,'/system/dict/data','修改字典数据信息','dict','PUT'),(36,'2021-12-09 19:19:16','2021-12-09 19:19:16',NULL,'/system/dict/data/:dictCode','删除字典数据信息','dict','DELETE'),(37,'2021-12-09 19:21:18','2021-12-09 19:21:18',NULL,'/system/menu/menuTreeSelect','获取菜单树','menu','GET'),(38,'2021-12-09 19:21:47','2021-12-09 19:21:47',NULL,'/system/menu/menuRole','获取角色菜单','menu','GET'),(39,'2021-12-09 19:22:42','2021-12-09 19:22:42',NULL,'/system/menu/roleMenuTreeSelect/:roleId','获取角色菜单树','menu','GET'),(40,'2021-12-09 19:23:17','2021-12-09 19:23:17',NULL,'/system/menu/menuPaths','获取角色菜单路径列表','menu','GET'),(41,'2021-12-09 19:23:40','2021-12-09 19:23:40',NULL,'/system/menu/list','获取菜单列表','menu','GET'),(42,'2021-12-09 19:24:09','2021-12-09 19:24:09',NULL,'/system/menu/:menuId','获取菜单信息','menu','GET'),(43,'2021-12-09 19:24:29','2021-12-09 19:24:29',NULL,'/system/menu','添加菜单信息','menu','POST'),(44,'2021-12-09 19:24:48','2021-12-09 19:24:48',NULL,'/system/menu','修改菜单信息','menu','PUT'),(45,'2021-12-09 19:25:10','2021-12-09 19:25:10',NULL,'/system/menu/:menuId','删除菜单信息','menu','DELETE'),(46,'2021-12-09 19:25:44','2021-12-09 19:27:06',NULL,'/system/post/list','获取岗位分页列表','post','GET'),(47,'2021-12-09 19:26:55','2021-12-09 19:26:55',NULL,'/system/post/:postId','获取岗位信息','post','GET'),(48,'2021-12-09 19:25:44','2021-12-09 19:25:44',NULL,'/system/post','添加岗位信息','post','POST'),(49,'2021-12-09 19:25:44','2021-12-09 19:25:44',NULL,'/system/post','修改岗位信息','post','PUT'),(50,'2021-12-09 19:25:44','2021-12-09 19:25:44',NULL,'/system/post/:postId','删除岗位信息','post','DELETE'),(51,'2021-12-09 19:25:44','2021-12-09 19:25:44',NULL,'/system/role/list','获取角色分页列表','role','GET'),(52,'2021-12-09 19:25:44','2021-12-09 19:25:44',NULL,'/system/role/:roleId','获取角色信息','role','GET'),(53,'2021-12-09 19:25:44','2021-12-09 19:25:44',NULL,'/system/role','添加角色信息','role','POST'),(54,'2021-12-09 19:25:44','2021-12-09 19:25:44',NULL,'/system/role','修改角色信息','role','PUT'),(55,'2021-12-09 19:25:44','2021-12-09 19:25:44',NULL,'/system/role/:roleId','删除角色信息','role','DELETE'),(56,'2021-12-09 19:25:44','2021-12-09 19:25:44',NULL,'/system/role/changeStatus','修改角色状态','role','PUT'),(57,'2021-12-09 19:25:44','2021-12-09 19:25:44',NULL,'/system/role/dataScope','修改角色部门权限','role','PUT'),(58,'2021-12-09 19:25:44','2021-12-09 19:25:44',NULL,'/system/role/export','导出角色信息','role','GET'),(59,'2021-12-09 19:50:57','2021-12-09 19:50:57',NULL,'/system/api/list','获取api分页列表','api','GET'),(60,'2021-12-09 19:51:26','2021-12-09 19:51:26',NULL,'/system/api/all','获取所有api','api','GET'),(61,'2021-12-09 19:51:54','2021-12-09 19:51:54',NULL,'/system/api/getPolicyPathByRoleId','获取角色拥有的api权限','api','GET'),(62,'2021-12-09 19:52:14','2021-12-09 19:52:14',NULL,'/system/api/:id','获取api信息','api','GET'),(63,'2021-12-09 19:52:35','2021-12-09 19:52:35',NULL,'/system/api','添加api信息','api','POST'),(64,'2021-12-09 19:52:50','2021-12-09 19:52:50',NULL,'/system/api','修改api信息','api','PUT'),(65,'2021-12-09 19:53:07','2021-12-09 19:53:07',NULL,'/system/api/:id','删除api信息','api','DELETE');
/*!40000 ALTER TABLE `sys_apis` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_configs`
--

DROP TABLE IF EXISTS `sys_configs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_configs` (
  `config_id` bigint NOT NULL AUTO_INCREMENT COMMENT '主键编码',
  `config_name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'ConfigName',
  `config_key` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'ConfigKey',
  `config_value` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'ConfigValue',
  `config_type` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '是否系统内置0，1',
  `is_frontend` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '是否前台',
  `remark` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'Remark',
  `create_time` datetime DEFAULT NULL,
  `update_time` datetime DEFAULT NULL,
  `delete_time` datetime DEFAULT NULL,
  PRIMARY KEY (`config_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_configs`
--

LOCK TABLES `sys_configs` WRITE;
/*!40000 ALTER TABLE `sys_configs` DISABLE KEYS */;
INSERT INTO `sys_configs` VALUES (1,'账号初始密码','sys.user.initPassword','123456','0','0','初始密码','2021-12-04 13:50:13','2021-12-04 13:54:52',NULL);
/*!40000 ALTER TABLE `sys_configs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_depts`
--

DROP TABLE IF EXISTS `sys_depts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_depts` (
  `dept_id` bigint NOT NULL AUTO_INCREMENT,
  `parent_id` int DEFAULT NULL COMMENT '上级部门',
  `dept_path` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '部门路径',
  `dept_name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '部门名称',
  `sort` int DEFAULT NULL COMMENT '排序',
  `leader` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '负责人',
  `phone` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '手机',
  `email` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '邮箱',
  `status` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '状态',
  `create_by` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '创建人',
  `update_by` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '修改人',
  `create_time` datetime DEFAULT NULL,
  `update_time` datetime DEFAULT NULL,
  `delete_time` datetime DEFAULT NULL,
  PRIMARY KEY (`dept_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_depts`
--

LOCK TABLES `sys_depts` WRITE;
/*!40000 ALTER TABLE `sys_depts` DISABLE KEYS */;
INSERT INTO `sys_depts` VALUES (2,0,'/0/2','熊猫科技',0,'xm','18353366836','342@qq.com','0','admin','admin','2021-12-01 17:31:53','2021-12-02 08:56:19',NULL),(3,2,'/3','研发部',1,'panda','18353366543','ewr@qq.com','0','admin','admin','2021-12-01 17:37:43','2021-12-02 08:55:56',NULL),(4,2,'/0/2/4','营销部',0,'lisa','18653366543','','1','admin','admin','2021-12-01 17:31:53','2021-12-02 09:02:20','2021-12-02 09:02:46');
/*!40000 ALTER TABLE `sys_depts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_dict_data`
--

DROP TABLE IF EXISTS `sys_dict_data`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_dict_data` (
  `dict_code` bigint NOT NULL AUTO_INCREMENT,
  `dict_sort` int DEFAULT NULL COMMENT '排序',
  `dict_label` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '标签',
  `dict_value` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '值',
  `dict_type` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '字典类型',
  `status` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '状态（0正常 1停用）',
  `css_class` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'CssClass',
  `list_class` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'ListClass',
  `is_default` varchar(8) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'IsDefault',
  `create_by` varchar(191) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `update_by` varchar(191) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `remark` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '备注',
  `create_time` datetime DEFAULT NULL,
  `update_time` datetime DEFAULT NULL,
  `delete_time` datetime DEFAULT NULL,
  PRIMARY KEY (`dict_code`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_dict_data`
--

LOCK TABLES `sys_dict_data` WRITE;
/*!40000 ALTER TABLE `sys_dict_data` DISABLE KEYS */;
INSERT INTO `sys_dict_data` VALUES (1,0,'男','0','sys_user_sex','0','','','','admin','','男','2021-11-30 14:58:18','2021-11-30 14:58:18',NULL),(2,1,'女','1','sys_user_sex','0','','','','admin','','女生','2021-11-30 15:09:11','2021-11-30 15:10:28',NULL),(3,2,'未知','2','sys_user_sex','0','','','','admin','','未知','2021-11-30 15:09:11','2021-11-30 15:10:28',NULL),(4,0,'正常','0','sys_normal_disable','0','','','','admin','','','2021-12-01 15:58:50','2021-12-01 15:58:50',NULL),(5,1,'停用','1','sys_normal_disable','0','','','','admin','','','2021-12-01 15:59:08','2021-12-01 15:59:08',NULL),(6,0,'目录','M','sys_menu_type','0','','','','admin','','','2021-12-02 09:49:12','2021-12-02 09:49:12',NULL),(7,1,'菜单','C','sys_menu_type','0','','','','admin','','','2021-12-02 09:49:35','2021-12-02 09:49:52',NULL),(8,2,'按钮','F','sys_menu_type','0','','','','admin','','','2021-12-02 09:49:35','2021-12-02 09:49:35',NULL),(9,0,'显示','0','sys_show_hide','0','','','','admin','','','2021-12-02 09:56:40','2021-12-02 09:56:40',NULL),(10,0,'隐藏','1','sys_show_hide','0','','','','admin','','','2021-12-02 09:56:52','2021-12-02 09:56:52',NULL),(11,0,'是','0','sys_num_yes_no','0','','','','admin','','','2021-12-02 10:16:16','2021-12-02 10:16:16',NULL),(12,1,'否','1','sys_num_yes_no','0','','','','admin','','','2021-12-02 10:16:26','2021-12-02 10:16:26',NULL),(13,0,'是','0','sys_yes_no','0','','','','admin','','','2021-12-04 13:48:15','2021-12-04 13:48:15',NULL),(14,0,'否','1','sys_yes_no','0','','','','admin','','','2021-12-04 13:48:21','2021-12-04 13:48:21',NULL),(15,0,'创建(POST)','POST','sys_method_api','0','','','','admin','','','2021-12-08 17:22:05','2021-12-09 09:29:52',NULL),(16,1,'查询(GET)','GET','sys_method_api','0','','','','admin','','','2021-12-08 17:22:24','2021-12-09 09:29:59',NULL),(17,2,'修改(PUT)','PUT','sys_method_api','0','','','','admin','','','2021-12-08 17:22:40','2021-12-09 09:30:06',NULL),(18,3,'删除(DELETE)','DELETE','sys_method_api','0','','','','admin','','','2021-12-08 17:22:54','2021-12-09 09:30:13',NULL);
/*!40000 ALTER TABLE `sys_dict_data` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_dict_types`
--

DROP TABLE IF EXISTS `sys_dict_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_dict_types` (
  `dict_id` bigint NOT NULL AUTO_INCREMENT,
  `dict_name` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '名称',
  `dict_type` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '类型',
  `status` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '状态',
  `create_by` varchar(191) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `update_by` varchar(191) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `remark` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '备注',
  `create_time` datetime DEFAULT NULL,
  `update_time` datetime DEFAULT NULL,
  `delete_time` datetime DEFAULT NULL,
  PRIMARY KEY (`dict_id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_dict_types`
--

LOCK TABLES `sys_dict_types` WRITE;
/*!40000 ALTER TABLE `sys_dict_types` DISABLE KEYS */;
INSERT INTO `sys_dict_types` VALUES (1,'用户性别','sys_user_sex','0','admin','','性别列表','2021-11-30 14:02:52','2021-11-30 14:07:55','2021-11-30 14:11:54'),(2,'用户性别','sys_user_sex','0','admin','','用户性别列表','2021-11-30 14:12:33','2021-11-30 14:12:33','2021-11-30 14:14:19'),(3,'的心','sfd','0','admin','','fs','2021-11-30 14:13:22','2021-11-30 14:13:22','2021-11-30 14:14:19'),(4,'用户性别','sys_user_sex','0','admin','','性别字典','2021-11-30 14:15:25','2021-11-30 14:15:25',NULL),(5,'df','da','0','admin','','sd','2021-11-30 15:54:33','2021-11-30 15:54:33','2021-11-30 15:54:40'),(6,'系统开关','sys_normal_disable','0','admin','','开关列表','2021-12-01 15:57:58','2021-12-01 15:57:58',NULL),(7,'菜单类型','sys_menu_type','0','admin','','菜单类型列表','2021-12-02 09:48:48','2021-12-02 09:56:12',NULL),(8,'菜单状态','sys_show_hide','0','admin','','菜单状态列表','2021-12-02 09:55:59','2021-12-02 09:55:59',NULL),(9,'数字是否','sys_num_yes_no','0','admin','','数字是否列表','2021-12-02 10:13:29','2021-12-02 10:13:40','2021-12-02 10:15:07'),(10,'数字是否','sys_num_yes_no','0','admin','','数字是否','2021-12-02 10:13:29','2021-12-02 10:13:29',NULL),(11,'状态是否','sys_yes_no','0','admin','','状态是否','2021-12-04 13:47:57','2021-12-04 13:47:57',NULL),(12,'网络请求方法','sys_method_api','0','admin','','网络请求方法列表','2021-12-08 17:21:27','2021-12-08 17:21:27',NULL);
/*!40000 ALTER TABLE `sys_dict_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_menus`
--

DROP TABLE IF EXISTS `sys_menus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_menus` (
  `menu_id` bigint NOT NULL AUTO_INCREMENT,
  `menu_name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `title` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `parent_id` int DEFAULT NULL,
  `sort` int DEFAULT NULL,
  `icon` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `path` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `component` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `is_frame` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `is_link` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `menu_type` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `is_hide` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `is_keep_alive` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `is_affix` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '是否登录后固定显示在页面顶部sheet',
  `permission` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `status` varchar(191) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `create_by` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `update_by` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `remark` varchar(191) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `create_time` datetime DEFAULT NULL,
  `update_time` datetime DEFAULT NULL,
  `delete_time` datetime DEFAULT NULL,
  PRIMARY KEY (`menu_id`)
) ENGINE=InnoDB AUTO_INCREMENT=62 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_menus`
--

LOCK TABLES `sys_menus` WRITE;
/*!40000 ALTER TABLE `sys_menus` DISABLE KEYS */;
INSERT INTO `sys_menus` VALUES (1,'系统设置','',0,0,'el-icon-s-tools','/system','Layout','1','','M','0','0','0','','0','admin','admin','','2021-12-02 11:04:08','2021-12-04 11:04:45',NULL),(3,'用户管理','',1,1,'el-icon-user','/system/user','/system/user/index','1','','C','0','1','0','system:user:list','0','admin','','','2021-12-02 14:07:56','2021-12-02 14:07:56',NULL),(4,'添加用户','',3,1,'','','','','','F','0','','','system:user:add','0','admin','','','2021-12-03 13:36:33','2021-12-03 13:36:33',NULL),(5,'编辑用户','',3,1,'','','','','','F','0','','','system:user:edit','0','admin','','','2021-12-03 13:48:13','2021-12-03 13:48:13',NULL),(6,'角色管理','',1,1,'el-icon-user-solid','/system/role','/system/role/index','1','','C','0','1','0','system:role:list','0','admin','admin','','2021-12-03 13:51:55','2021-12-03 13:55:04',NULL),(7,'菜单管理','',1,2,'el-icon-menu','/system/menu','/system/menu/index','1','','C','0','1','0','system:menu:list','0','admin','admin','','2021-12-03 13:54:44','2021-12-03 13:58:55',NULL),(8,'部门管理','',1,3,'el-icon-set-up','/system/dept','/system/dept/index','1','','C','0','1','0','system:dept:list','0','admin','','','2021-12-03 13:58:36','2021-12-03 13:58:36',NULL),(9,'岗位管理','',1,4,'el-icon-s-flag','/system/post','/system/post/index','1','','C','0','1','0','system:post:list','0','admin','','','2021-12-03 13:54:44','2021-12-03 13:54:44',NULL),(10,'字典管理','',1,5,'el-icon-s-order','/system/dict','/system/dict/index','1','','C','0','1','0','system:dict:list','0','admin','','','2021-12-03 13:54:44','2021-12-03 13:54:44',NULL),(11,'参数管理','',1,6,'el-icon-document','/system/config','/system/config/index','1','','C','0','1','0','system:config:list','0','admin','admin','','2021-12-03 13:54:44','2021-12-03 17:06:35',NULL),(12,'个人中心',NULL,0,2,'el-icon-s-custom','/personal','/personal/index','1',NULL,'M','0','0','0',NULL,'0',NULL,'admin',NULL,NULL,'2022-04-25 09:28:40',NULL),(13,'添加配置','',11,1,'','','','','','F','','','','system:config:add','0','admin','','','2021-12-06 17:19:19','2021-12-06 17:19:19',NULL),(14,'修改配置','',11,1,'','','','','','F','','','','system:config:edit','0','admin','','','2021-12-06 17:20:30','2021-12-06 17:20:30',NULL),(15,'删除配置','',11,1,'','','','','','F','','','','system:config:delete','0','admin','','','2021-12-06 17:23:52','2021-12-06 17:23:52',NULL),(16,'导出配置','',11,1,'','','','','','F','','','','system:config:export','0','admin','','','2021-12-06 17:24:41','2021-12-06 17:24:41',NULL),(17,'新增角色','',6,1,'','','','','','F','','','','system:role:add','0','admin','','','2021-12-06 17:43:35','2021-12-06 17:43:35',NULL),(18,'删除角色','',6,1,'','','','','','F','','','','system:role:delete','0','admin','','','2021-12-06 17:44:10','2021-12-06 17:44:10',NULL),(19,'修改角色','',6,1,'','','','','','F','','','','system:role:edit','0','admin','','','2021-12-06 17:44:48','2021-12-06 17:44:48',NULL),(20,'导出角色','',6,1,'','','','','','F','','','','system:role:export','0','admin','','','2021-12-06 17:45:25','2021-12-06 17:45:25',NULL),(21,'添加菜单','',7,1,'','','','','','F','','','','system:menu:add','0','admin','','','2021-12-06 17:46:01','2021-12-06 17:46:01',NULL),(22,'修改菜单','',7,1,'','','','','','F','','','','system:menu:edit','0','admin','','','2021-12-06 17:46:24','2021-12-06 17:46:24',NULL),(23,'删除菜单','',7,1,'','','','','','F','','','','system:menu:delete','0','admin','','','2021-12-06 17:46:47','2021-12-06 17:46:47',NULL),(24,'添加部门','',8,1,'','','','','','F','','','','system:dept:add','0','admin','','','2021-12-07 09:33:58','2021-12-07 09:33:58',NULL),(25,'编辑部门','',8,1,'','','','','','F','','','','system:dept:edit','0','admin','','','2021-12-07 09:34:39','2021-12-07 09:34:39',NULL),(26,'删除部门','',8,1,'','','','','','F','','','','system:dept:delete','0','admin','admin','','2021-12-07 09:35:09','2021-12-07 09:36:26',NULL),(27,'导出部门','',8,1,'','','','','','F','','','','system:dept:export','0','admin','','','2021-12-07 09:35:51','2021-12-07 09:35:51','2021-12-07 09:36:37'),(28,'添加岗位','',9,1,'','','','','','F','','','','system:post:add','0','admin','','','2021-12-07 09:35:09','2021-12-07 09:35:09',NULL),(29,'编辑岗位','',9,1,'','','','','','F','','','','system:post:edit','0','admin','','','2021-12-07 09:35:09','2021-12-07 09:35:09',NULL),(30,'删除岗位','',9,1,'','','','','','F','','','','system:post:delete','0','admin','','','2021-12-07 09:35:09','2021-12-07 09:35:09',NULL),(31,'导出岗位','',9,1,'','','','','','F','','','','system:post:export','0','admin','','','2021-12-07 09:35:09','2021-12-07 09:35:09',NULL),(32,'添加字典类型','',10,1,'','','','','','F','','','','system:dictT:add','0','admin','','','2021-12-07 09:35:09','2021-12-07 09:35:09',NULL),(33,'编辑字典类型','',10,1,'','','','','','F','','','','system:dictT:edit','0','admin','','','2021-12-07 09:35:09','2021-12-07 09:35:09',NULL),(34,'删除字典类型','',10,1,'','','','','','F','','','','system:dictT:delete','0','admin','','','2021-12-07 09:35:09','2021-12-07 09:35:09',NULL),(35,'导出字典类型','',10,1,'','','','','','F','','','','system:dictT:export','0','admin','','','2021-12-07 09:35:09','2021-12-07 09:35:09',NULL),(36,'新增字典数据','',10,1,'','','','','','F','','','','system:dictD:add','0','admin','','','2021-12-07 09:35:09','2021-12-07 09:35:09',NULL),(37,'修改字典数据','',10,1,'','','','','','F','','','','system:dictD:edit','0','admin','','','2021-12-07 09:48:04','2021-12-07 09:48:04',NULL),(38,'删除字典数据','',10,1,'','','','','','F','','','','system:dictD:delete','0','admin','','','2021-12-07 09:48:42','2021-12-07 09:48:42',NULL),(39,'API管理','',1,1,'iconfont icon-siweidaotu','/system/api','/system/api/index','1','','C','0','1','0','system:api:list','0','admin','','','2021-12-09 09:09:13','2021-12-09 09:09:13',NULL),(40,'添加api','',39,1,'','/system/api','','','','F','','','','system:api:add','0','admin','','','2021-12-09 09:09:54','2021-12-09 09:09:54',NULL),(41,'编辑api','',39,1,'','/system/api','','','','F','','','','system:api:edit','0','admin','','','2021-12-09 09:10:38','2021-12-09 09:10:38',NULL),(42,'删除api','',39,1,'','/system/api','','','','F','','','','system:api:delete','0','admin','','','2021-12-09 09:11:11','2021-12-09 09:11:11',NULL),(43,'数据管理',NULL,0,3,'el-icon-s-claim','/device','Layout','0',NULL,'M','0','0','0',NULL,'0',NULL,'',NULL,NULL,'2023-04-28 21:25:48',NULL),(44,'搅拌桩',NULL,43,5,'el-icon-ice-cream-square','/device/jiaobanzhuang','/device/jiaobanzhuang/index','0',NULL,'C','0','1','0','device:jiaobanzhuang:list','0',NULL,'',NULL,NULL,'2023-04-28 21:30:40',NULL),(45,'跌倒报警器',NULL,43,2,'el-icon-s-marketing','/device/falldowndevice','/device/falldowndevice/index','0',NULL,'C','0','0','0',NULL,'0',NULL,'',NULL,NULL,'2021-12-26 22:28:35',NULL),(46,'报警器地图','',43,3,'el-icon-location','','/layout/routerView/iframes','1','https://www.gdjtypt.com/WlDeviceMng/HunNingTu/Index?deviceId=NBHYGS_MP2_1&manage=1','C','0','0','0','','0',NULL,'admin',NULL,NULL,'2021-12-26 23:56:57',NULL),(47,'添加报警器',NULL,45,1,NULL,NULL,NULL,NULL,NULL,'F',NULL,NULL,NULL,'device:falldowndevice:add','0','',NULL,NULL,'2021-12-30 19:19:52',NULL,NULL),(48,'编辑报警器',NULL,45,2,NULL,NULL,NULL,NULL,NULL,'F',NULL,NULL,NULL,'device:falldowndevice:edit','0','',NULL,NULL,'2021-12-30 19:21:44',NULL,NULL),(49,'删除报警器',NULL,45,2,NULL,NULL,NULL,NULL,NULL,'F',NULL,NULL,NULL,'device:falldowndevice:delete','0','',NULL,NULL,'2021-12-30 19:22:18',NULL,NULL),(53,'地图模式',NULL,43,4,'fa fa-map-o','/device/map','/device/map/index','1',NULL,'C','0','1','0','device:map:list','0',NULL,'',NULL,NULL,'2022-01-13 23:43:31',NULL),(54,'科研管理',NULL,0,4,'fa fa-chrome','/research','Layout','0',NULL,'M','0','0','0',' ','0',NULL,'admin',NULL,NULL,'2022-02-07 00:40:23',NULL),(55,'科研项目',NULL,54,1,'el-icon-c-scale-to-original','/research/project','/research/project/index','0',NULL,'C','0','1','0','research:project:list','0',NULL,'admin',NULL,NULL,'2022-02-07 00:38:59',NULL),(56,'科研论文',NULL,54,2,'el-icon-notebook-2','/research/paper','/research/paper/index','0',NULL,'C','0','1','0',NULL,'0',NULL,'',NULL,NULL,'2022-02-08 22:34:22',NULL),(57,'科研业绩点',NULL,54,3,'el-icon-bangzhu','/research/credit','/research/credit/index','0',NULL,'C','0','1','0',NULL,'0',NULL,'',NULL,NULL,'2022-02-08 22:41:23',NULL),(58,'原始数据',NULL,43,1,'fa fa-camera-retro','/radardata/rawdata','/radardata/rawdata/index','0',NULL,'C','0','0','0',NULL,'0',NULL,'admin',NULL,NULL,'2023-04-29 22:46:29',NULL),(59,'添加原始数据',NULL,58,1,NULL,'',NULL,NULL,NULL,'F',NULL,NULL,NULL,'radarData:rawData:add','0',NULL,'admin',NULL,NULL,'2023-04-28 22:00:56',NULL),(60,'编辑原始数据',NULL,58,2,NULL,'',NULL,NULL,NULL,'F',NULL,NULL,NULL,'radarData:rawData:edit','0',NULL,'admin',NULL,NULL,'2023-04-28 22:02:12',NULL),(61,'删除原始数据',NULL,58,3,NULL,'',NULL,NULL,NULL,'F',NULL,NULL,NULL,'radarData:rawData:delete','0',NULL,'admin',NULL,NULL,'2023-04-28 22:02:49',NULL);
/*!40000 ALTER TABLE `sys_menus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_posts`
--

DROP TABLE IF EXISTS `sys_posts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_posts` (
  `post_id` bigint NOT NULL AUTO_INCREMENT,
  `post_name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '岗位名称',
  `post_code` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '岗位代码',
  `sort` int DEFAULT NULL COMMENT '岗位排序',
  `status` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '状态',
  `remark` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '描述',
  `create_by` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `update_by` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `create_time` datetime DEFAULT NULL,
  `update_time` datetime DEFAULT NULL,
  `delete_time` datetime DEFAULT NULL,
  PRIMARY KEY (`post_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_posts`
--

LOCK TABLES `sys_posts` WRITE;
/*!40000 ALTER TABLE `sys_posts` DISABLE KEYS */;
INSERT INTO `sys_posts` VALUES (1,'首席执行官','CEO',0,'0','首席执行官','admin','','2021-12-02 09:21:44','2021-12-02 09:24:25',NULL),(3,'首席技术执行官','CTO',1,'0','','admin','','2021-12-02 09:21:44','2021-12-02 09:25:59','2021-12-02 09:27:41'),(4,'首席技术执行官','CTO',1,'0','','admin','','2021-12-02 09:21:44','2021-12-02 09:25:59',NULL);
/*!40000 ALTER TABLE `sys_posts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_role_depts`
--

DROP TABLE IF EXISTS `sys_role_depts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_role_depts` (
  `role_id` int DEFAULT NULL,
  `dept_id` int DEFAULT NULL,
  `id` bigint NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_role_depts`
--

LOCK TABLES `sys_role_depts` WRITE;
/*!40000 ALTER TABLE `sys_role_depts` DISABLE KEYS */;
INSERT INTO `sys_role_depts` VALUES (1,2,1),(1,3,2);
/*!40000 ALTER TABLE `sys_role_depts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_role_menus`
--

DROP TABLE IF EXISTS `sys_role_menus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_role_menus` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `role_id` int DEFAULT NULL,
  `menu_id` int DEFAULT NULL,
  `role_name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=896 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_role_menus`
--

LOCK TABLES `sys_role_menus` WRITE;
/*!40000 ALTER TABLE `sys_role_menus` DISABLE KEYS */;
INSERT INTO `sys_role_menus` VALUES (767,2,43,'common'),(768,2,12,'common'),(769,2,58,'common'),(827,1,1,'admin'),(828,1,3,'admin'),(829,1,4,'admin'),(830,1,5,'admin'),(831,1,6,'admin'),(832,1,17,'admin'),(833,1,18,'admin'),(834,1,19,'admin'),(835,1,20,'admin'),(836,1,7,'admin'),(837,1,21,'admin'),(838,1,22,'admin'),(839,1,23,'admin'),(840,1,8,'admin'),(841,1,24,'admin'),(842,1,25,'admin'),(843,1,26,'admin'),(844,1,27,'admin'),(845,1,9,'admin'),(846,1,28,'admin'),(847,1,29,'admin'),(848,1,30,'admin'),(849,1,31,'admin'),(850,1,10,'admin'),(851,1,32,'admin'),(852,1,33,'admin'),(853,1,34,'admin'),(854,1,35,'admin'),(855,1,36,'admin'),(856,1,37,'admin'),(857,1,38,'admin'),(858,1,11,'admin'),(859,1,13,'admin'),(860,1,14,'admin'),(861,1,15,'admin'),(862,1,16,'admin'),(863,1,39,'admin'),(864,1,40,'admin'),(865,1,41,'admin'),(866,1,42,'admin'),(867,1,12,'admin'),(868,1,43,'admin'),(869,1,44,'admin'),(870,1,45,'admin'),(871,1,47,'admin'),(872,1,48,'admin'),(873,1,49,'admin'),(874,1,46,'admin'),(875,1,53,'admin'),(876,1,58,'admin'),(877,1,59,'admin'),(878,1,60,'admin'),(879,1,61,'admin'),(880,1,54,'admin'),(881,1,55,'admin'),(882,1,56,'admin'),(883,1,57,'admin'),(884,3,43,'guest'),(885,3,44,'guest'),(886,3,45,'guest'),(887,3,47,'guest'),(888,3,48,'guest'),(889,3,49,'guest'),(890,3,46,'guest'),(891,3,53,'guest'),(892,3,58,'guest'),(893,3,59,'guest'),(894,3,60,'guest'),(895,3,61,'guest');
/*!40000 ALTER TABLE `sys_role_menus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_roles`
--

DROP TABLE IF EXISTS `sys_roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_roles` (
  `role_id` bigint NOT NULL AUTO_INCREMENT,
  `role_name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '角色名称',
  `status` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '状态',
  `role_key` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '角色代码',
  `data_scope` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '数据范围（1：全部数据权限 2：自定数据权限 3：本部门数据权限 4：本部门及以下数据权限）',
  `role_sort` int DEFAULT NULL COMMENT '角色排序',
  `flag` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '删除标识',
  `create_by` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `update_by` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `create_time` datetime DEFAULT NULL,
  `update_time` datetime DEFAULT NULL,
  `delete_time` datetime DEFAULT NULL,
  PRIMARY KEY (`role_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_roles`
--

LOCK TABLES `sys_roles` WRITE;
/*!40000 ALTER TABLE `sys_roles` DISABLE KEYS */;
INSERT INTO `sys_roles` VALUES (1,'超管理员','0','admin','2',1,NULL,'admin','admin',NULL,'2021-12-02 16:03:26','2023-04-29 22:45:52',NULL),(2,'普通员工','0','common',NULL,2,NULL,'2021/12/25 21:09:12','admin',NULL,NULL,'2023-04-28 21:37:07',NULL),(3,'临时客户','0','guest',NULL,3,NULL,'admin',NULL,'测试','2021-12-25 23:18:56','2023-05-04 16:53:30',NULL);
/*!40000 ALTER TABLE `sys_roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_users`
--

DROP TABLE IF EXISTS `sys_users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_users` (
  `user_id` bigint NOT NULL AUTO_INCREMENT,
  `nick_name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `phone` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `role_id` int DEFAULT NULL,
  `salt` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `avatar` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `sex` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `email` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `dept_id` int DEFAULT NULL,
  `post_id` int DEFAULT NULL,
  `create_by` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `update_by` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `status` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `create_time` datetime DEFAULT NULL,
  `update_time` datetime DEFAULT NULL,
  `delete_time` datetime DEFAULT NULL,
  `username` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `password` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `role_ids` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '多角色',
  `post_ids` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '多岗位',
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_users`
--

LOCK TABLES `sys_users` WRITE;
/*!40000 ALTER TABLE `sys_users` DISABLE KEYS */;
INSERT INTO `sys_users` VALUES (1,'pandax','13818888888',1,NULL,'','0','1@qq.com',2,1,'admin','1',NULL,'0','2021-12-03 09:46:55','2021-12-03 10:51:34',NULL,'admin','E10ADC3949BA59ABBE56E057F20F883E','1','1'),(2,'测试用户','18353366754',1,'','','0','1234@163.com',3,4,'admin','','test','0','2021-12-03 10:11:11','2021-12-03 11:23:59','2021-12-03 11:24:38','test','$2a$10$Xj35fNwCNbqcXWByNbd8/e0CrN0vqoDToqFxpOQDzhk4pN59Cm9Gu',NULL,''),(3,'我们的','18435234356',NULL,NULL,NULL,NULL,'342@163.com',3,1,'admin',NULL,'123','0','2021-12-06 15:16:53','2021-12-06 15:29:28',NULL,'test',NULL,'1','1'),(4,'test1',NULL,NULL,NULL,NULL,'1',NULL,4,1,NULL,NULL,NULL,'0',NULL,NULL,NULL,'test1','C33367701511B4F6020EC61DED352059','2','1,3');
/*!40000 ALTER TABLE `sys_users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-03-10 22:42:37
