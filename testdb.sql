USE [master]
GO

/****** Object:  Database [wth]    Script Date: 15/07/2017 5:02:05 CH ******/
CREATE DATABASE [wth]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'wth', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\wth.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'wth_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\wth_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [wth] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [wth].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [wth] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [wth] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [wth] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [wth] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [wth] SET ARITHABORT OFF 
GO

ALTER DATABASE [wth] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [wth] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [wth] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [wth] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [wth] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [wth] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [wth] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [wth] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [wth] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [wth] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [wth] SET  ENABLE_BROKER 
GO

ALTER DATABASE [wth] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [wth] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [wth] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [wth] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [wth] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [wth] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [wth] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [wth] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [wth] SET  MULTI_USER 
GO

ALTER DATABASE [wth] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [wth] SET DB_CHAINING OFF 
GO

ALTER DATABASE [wth] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [wth] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [wth] SET  READ_WRITE 
GO
