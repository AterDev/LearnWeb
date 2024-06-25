public class FileSearch
{
    /// <summary>
    /// 搜索文件
    /// </summary>
    /// <param name="path">根目录</param>
    /// <param name="extensions">后缀</param>
    /// <returns></returns>
    public string[] SearchFiles(string path, params string[] extensions)
    {
        // 如果只搜索一种后缀，则直接搜索并返回
        if (extensions.Length == 1)
        {
            return Directory.GetFiles(path, extensions[0], SearchOption.AllDirectories);
        }
        else
        {
            // 多个后缀时，先获取所有文件，再筛选
            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            List<string> filteredFiles = [];
            foreach (string file in files)
            {
                string extension = Path.GetExtension(file); // 获取后缀名

                // 将符合要求的后缀名添加到列表中
                if (extensions.Contains(extension))
                {
                    filteredFiles.Add(file);
                }
            }
            return filteredFiles.ToArray();
        }
    }

    /// <summary>
    /// 移动文件
    /// </summary>
    /// <param name="files">要移动的文件</param>
    /// <param name="targetPath">目标目录</param>
    public void MoveFiles(string[] files, string targetPath)
    {
        foreach (string file in files)
        {
            // 如文件路径为 c:\download\xxxx\abc.jpg
            string extension = Path.GetExtension(file); //  获取后缀名 .jpg
            string fileName = Path.GetFileName(file); // 获取文件名  abc.jpg

            string destPath = Path.Combine(targetPath, fileName);
            if (File.Exists(destPath))
            {
                // 如果文件已存在，则在文件名后添加随机字符串
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file); // 获取文件名 abc
                var randomString = Guid.NewGuid().ToString().Substring(0, 4); // 生成随机字符串
                var newFileName = fileNameWithoutExtension + "_" + randomString + extension; // 拼成新的文件名，如 abc_1234.jpg

                destPath = Path.Combine(targetPath, newFileName);
            }
            File.Move(file, destPath);
        }
    }
}