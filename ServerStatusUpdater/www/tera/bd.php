<?php
error_reporting(0);
session_start();
mysql_connect ("localhost","root","");  // HOST.login.pass
mysql_select_db ("tera");  //database
mysql_query("SET NAMES utf8");
$login = $_SESSION['login'];
$password = $_SESSION['password'];
$id_user = $_SESSION['id'];
?>