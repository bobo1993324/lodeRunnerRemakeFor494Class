using UnityEngine;
using System.Collections;

public class MapCustom
{
	public string xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<map version=""1.0"" orientation=""orthogonal"" renderorder=""right-down"" width=""40"" height=""25"" tilewidth=""32"" tileheight=""32"">
 <properties>
  <property name=""AddComp"" value=""MyComponent""/>
  <property name=""unity:scale"" value=""0.01""/>
 </properties>
 <tileset firstgid=""1"" name=""floor"" tilewidth=""32"" tileheight=""32"">
  <image source=""D:/Game/lodeRunnerRemakeFor494Class/Assets/Sprites/floor.jpg"" width=""33"" height=""32""/>
  <tile id=""0"">
   <objectgroup draworder=""index"">
    <object x=""0"" y=""0"" width=""32"" height=""32""/>
   </objectgroup>
  </tile>
 </tileset>
 <tileset firstgid=""2"" name=""ladder"" tilewidth=""32"" tileheight=""32"">
  <image source=""D:/Game/lodeRunnerRemakeFor494Class/Assets/Sprites/ladder.jpg"" trans=""ff00ff"" width=""32"" height=""32""/>
 </tileset>
 <tileset firstgid=""3"" name=""gold"" tilewidth=""32"" tileheight=""32"">
  <image source=""D:/Game/lodeRunnerRemakeFor494Class/Assets/Sprites/gold.jpg"" width=""32"" height=""32""/>
 </tileset>
 <tileset firstgid=""4"" name=""hard floor"" tilewidth=""32"" tileheight=""32"">
  <image source=""D:/Game/lodeRunnerRemakeFor494Class/Assets/Sprites/hard floor.jpg"" width=""32"" height=""32""/>
  <tile id=""0"">
   <objectgroup draworder=""index"">
    <object x=""0"" y=""0"" width=""32"" height=""32""/>
   </objectgroup>
  </tile>
 </tileset>
 <tileset firstgid=""5"" name=""stick"" tilewidth=""32"" tileheight=""32"">
  <image source=""D:/Game/lodeRunnerRemakeFor494Class/Assets/Sprites/stick.jpg"" width=""32"" height=""32""/>
 </tileset>
 <tileset firstgid=""6"" name=""runner"" tilewidth=""32"" tileheight=""32"">
  <image source=""../Sprites/runner.png"" width=""32"" height=""32""/>
 </tileset>
 <tileset firstgid=""7"" name=""chaser"" tilewidth=""32"" tileheight=""32"">
  <image source=""../Sprites/chaser.png"" width=""32"" height=""32""/>
 </tileset>
 <tileset firstgid=""8"" name=""hiddenLadder"" tilewidth=""32"" tileheight=""32"">
  <image source=""../Sprites/hiddenLadder.jpg"" width=""32"" height=""32""/>
 </tileset>
 <layer name=""Map"" width=""40"" height=""25"">
  <data>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""8""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""7""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""8""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""8""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""8""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""4""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""8""/>
   <tile gid=""0""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""2""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""8""/>
   <tile gid=""0""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""7""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""3""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""3""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""7""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""8""/>
   <tile gid=""0""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""8""/>
   <tile gid=""0""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""8""/>
   <tile gid=""0""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""8""/>
   <tile gid=""0""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""3""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""3""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""3""/>
   <tile gid=""0""/>
   <tile gid=""8""/>
   <tile gid=""0""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""2""/>
   <tile gid=""2""/>
   <tile gid=""2""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""2""/>
   <tile gid=""2""/>
   <tile gid=""2""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""3""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""7""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""3""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""7""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""3""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""3""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""3""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""5""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""6""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""3""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""0""/>
   <tile gid=""2""/>
   <tile gid=""0""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""2""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""2""/>
   <tile gid=""1""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""1""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
   <tile gid=""4""/>
  </data>
 </layer>
</map>
";
}

