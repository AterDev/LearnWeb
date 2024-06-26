using System.IO.Compression;

string targetPath = @"d:\images";
string zipPath = @"d:\images.zip";
string unzipPath = @"d:\unzip";
// 直接使用静态方法，将目录压缩为zip文件
ZipFile.CreateFromDirectory(targetPath, zipPath);

// 使用静态方法，解压文件到指定目录
ZipFile.ExtractToDirectory(zipPath, unzipPath);