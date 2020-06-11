using System;
using System.IO;

/// <summary>
/// FileUtil
/// 文件读写工具类
/// </summary>
public class FileUtil
{
    /// <summary>
    /// FileOperationResult
    /// 文件操作结果类
    /// </summary>
    public class FileOperationResult : IDisposable
    {
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool Success { get; private set; }

        /// <summary>
        /// 文件数据
        /// </summary>
        public object Data { get; private set; }

        /// <summary>
        /// 操作报错
        /// </summary>
        public string Error { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="success"></param>
        /// <param name="data"></param>
        /// <param name="error"></param>
        public FileOperationResult(bool success, object data, string error)
        {
            Success = success;
            Data = data;
            Error = error;
        }

        /// <summary>
        /// 销毁
        /// </summary>
        public void Dispose()
        {
            Success = false;
            Data = null;
            Error = null;
        }
    }

    /// <summary>
    /// 是否是文件夹
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static bool IsDirectory(string path)
    {
        return Directory.Exists(path);
    }

    /// <summary>
    /// 是否是文件
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static bool IsFile(string path)
    {
        return File.Exists(path);
    }

    /// <summary>
    /// 确保一个路径(目录/文件)存在
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private static bool ValidatePath(string path)
    {
        if (string.IsNullOrEmpty(path) == true)
        {
            return false;
        }
        path = path.Substring(0, path.LastIndexOf('/'));
        if (Directory.Exists(path) == true)
        {
            return true;
        }

        Directory.CreateDirectory(path);
        return Directory.Exists(path);
    }

    /// <summary>
    /// 文件是否存在
    /// </summary>
    public static bool Exists(string filePath)
    {
        return File.Exists(filePath);
    }

    /// <summary>
    /// 获取文件字节数
    /// </summary>
    public static long GetFileLength(string filePath)
    {
        var fileInfo = new FileInfo(filePath);
        if (fileInfo.Exists)
        {
            return fileInfo.Length;
        }
        return -1;
    }

    /// <summary>
    /// 读取所有文本
    /// </summary>
    public static FileOperationResult ReadAllText(string path)
    {
        if (string.IsNullOrEmpty(path) == true)
        {
            return new FileOperationResult(false, null, "Invalid path.");
        }

        path = path.Replace('\\', '/');
        try
        {
            if (File.Exists(path) == true)
            {
                var data = File.ReadAllText(path);
                return new FileOperationResult(true, data, null);
            }
            else
            {
                return new FileOperationResult(false, null, "Invalid path.");
            }
        }
        catch (Exception e)
        {
            return new FileOperationResult(false, null, e.Message);
        }
    }

    /// <summary>
    /// 读取所有字节
    /// </summary>
    public static FileOperationResult ReadAllBytes(string path)
    {
        if (string.IsNullOrEmpty(path) == true)
        {
            return new FileOperationResult(false, null, "Invalid path.");
        }

        path = path.Replace('\\', '/');
        try
        {
            if (File.Exists(path) == true)
            {
                byte[] data = File.ReadAllBytes(path);
                return new FileOperationResult(true, data, null);
            }
            else
            {
                return new FileOperationResult(false, null, "Invalid path.");
            }
        }
        catch (Exception e)
        {
            return new FileOperationResult(false, null, e.Message);
        }
    }

    /// <summary>
    /// 读取所有行
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static FileOperationResult ReadAllLines(string path)
    {
        if (string.IsNullOrEmpty(path) == true)
        {
            return new FileOperationResult(false, null, "Invalid path.");
        }

        path = path.Replace('\\', '/');
        try
        {
            if (File.Exists(path) == true)
            {
                string[] data = File.ReadAllLines(path);
                return new FileOperationResult(true, data, null);
            }
            else
            {
                return new FileOperationResult(false, null, "Invalid path.");
            }
        }
        catch (Exception e)
        {
            return new FileOperationResult(false, null, e.Message);
        }
    }

    /// <summary>
    /// 向文件中写入指定内容
    /// </summary>
    /// <param name="path"></param>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static FileOperationResult WriteAllBytes(string path, byte[] bytes)
    {
        if (string.IsNullOrEmpty(path) == true)
        {
            return new FileOperationResult(false, null, "Invalid path");
        }

        path = path.Replace('\\', '/');
        try
        {
            if (ValidatePath(path) == true)
            {
                File.WriteAllBytes(path, bytes);
                return new FileOperationResult(true, null, null);
            }
            else
            {
                return new FileOperationResult(false, null, "Create directory failed.");
            }
        }
        catch (Exception e)
        {
            return new FileOperationResult(false, null, e.Message);
        }
    }

    /// <summary>
    /// 向文件中写入字符串
    /// </summary>
    /// <param name="path"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    public static FileOperationResult WriteAllText(string path, string text)
    {
        if (string.IsNullOrEmpty(path) == true)
        {
            return new FileOperationResult(false, null, "Invalid path.");
        }

        path = path.Replace('\\', '/');
        try
        {
            if (ValidatePath(path) == true)
            {
                File.WriteAllText(path, text);
                return new FileOperationResult(true, null, null);
            }
            else
            {
                return new FileOperationResult(false, null, "Create directory failed.");
            }
        }
        catch (Exception e)
        {
            return new FileOperationResult(false, null, e.Message);
        }
    }

    /// <summary>
    /// 向文件中按行写入
    /// </summary>
    /// <param name="path"></param>
    /// <param name="lines"></param>
    /// <returns></returns>
    public static FileOperationResult WriteAllLines(string path, string[] lines)
    {
        if (string.IsNullOrEmpty(path) == true)
        {
            return new FileOperationResult(false, null, "Invalid path.");
        }

        path = path.Replace('\\', '/');
        try
        {
            if (ValidatePath(path) == true)
            {
                File.WriteAllLines(path, lines);
                return new FileOperationResult(true, null, null);
            }
            else
            {
                return new FileOperationResult(false, null, "Create directory failed.");
            }
        }
        catch (Exception e)
        {
            return new FileOperationResult(false, null, e.Message);
        }
    }
    
    /// <summary>
    /// 删除文件/文件夹
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static FileOperationResult DeleteFile(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return new FileOperationResult(false, null, "Invalid path.");
        }

        path = path.Replace('\\', '/');
        try
        {
            File.Delete(path);
        }
        catch (Exception e)
        {
            return new FileOperationResult(false, null, e.Message);
        }
        
        return new FileOperationResult(true, null, null);
    }

    public static FileOperationResult DeleteDirectory(string path)
    {
        if(!IsDirectory(path)) return new FileOperationResult(false, null, "the folder to delete is not a directory");
        try
        {
            Directory.Delete(path);
        }
        catch (Exception e)
        {
            return new FileOperationResult(false, null, e.ToString());
        }


        return new FileOperationResult(true, null, "delete directory success");
    }

    /// <summary>
    /// 移动文件/文件夹
    /// </summary>
    /// <param name="source"></param>
    /// <param name="dest"></param>
    /// <param name="overwrite"></param>
    /// <returns></returns>
    public static FileOperationResult Move(string source, string dest, bool overwrite = true)
    {
        if (IsFile(source)) MoveFile(source, dest, overwrite);
        return IsDirectory(source) ? MoveDirectory(source, dest, overwrite) : new FileOperationResult(false, null, "Unknown error");
    }

    /// <summary>
    /// 移动文件或文件夹
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dest"></param>
    /// <param name="overwirte"></param>
    /// <returns></returns>
    public static FileOperationResult MoveFile(string src, string dest, bool overwrite = true)
    {
        if (string.IsNullOrEmpty(src) == true || string.IsNullOrEmpty(dest) == true)
        {
            return new FileOperationResult(false, null, "Invalid path.");
        }
        if (File.Exists(src) == false)
        {
            return new FileOperationResult(false, null, "Srouce file not exist.");
        }

        try
        {
            if (File.Exists(dest))
            {
                if (overwrite)
                {
                    File.Delete(dest);
                }
                else
                {
                    return new FileOperationResult(false, null, "Dest file exist.");
                }
            }
            File.Move(src, dest);
            return new FileOperationResult(true, null, null);
        }
        catch (Exception e)
        {
            return new FileOperationResult(false, null, e.Message);
        }
    }

    /// <summary>
    /// 移动文件夹
    /// </summary>
    /// <param name="sourceFolder"></param>
    /// <param name="destFolder"></param>
    /// <returns></returns>
    public static FileOperationResult MoveDirectory(string sourceFolder, string destFolder, bool overwrite = true)
    {
        if (!IsDirectory(sourceFolder) || !IsDirectory(destFolder))
        {
            return new FileOperationResult(false, null, "source folder or dest folder is not directory");
        }

        try
        {
            if (Directory.Exists(destFolder))
            {
                if (overwrite)
                {
                    Directory.Delete(destFolder);
                }
                else
                {
                    return new FileOperationResult(false, null, "folder is exits");
                }
            }

            Directory.Move(sourceFolder, destFolder);
        }
        catch (Exception e)
        {
            return new FileOperationResult(false, null, e.ToString());
        }

        return new FileOperationResult(true, null, "Move folder success");
    }

    /// <summary>
    /// 拷贝文件/文件夹
    /// </summary>
    /// <param name="source">原文件/文件夹路径</param>
    /// <param name="dest">目标文件/文件夹路径</param>
    /// <returns></returns>
    public static FileOperationResult Copy(string source, string dest)
    {
        if (IsFile(source)) return CopyFile(source, dest);
        return IsDirectory(source) ? CopyDirectory(source, dest) : new FileOperationResult(false, null, "unknown file type");
    }

    /// <summary>
    /// 文件拷贝
    /// </summary>
    /// <param name="sourceFile"></param>
    /// <param name="destFile"></param>
    /// <returns></returns>
    public static FileOperationResult CopyFile(string sourceFile, string destFile)
    {
        if (!IsFile(sourceFile)) return new FileOperationResult(false, null, "source file is not a file");
        try
        {
            File.Copy(sourceFile, destFile);
        }
        catch (Exception e)
        {
            return new FileOperationResult(false, null, e.ToString());
        }
        return new FileOperationResult(true, null, "copy file success");
    }

    /// <summary>
    /// 文件夹拷贝
    /// </summary>
    /// <param name="sourceFolder"></param>
    /// <param name="destFolder"></param>
    /// <returns></returns>
    public static FileOperationResult CopyDirectory(string sourceFolder, string destFolder)
    {
        if(!IsDirectory(sourceFolder)) return new FileOperationResult(false, null, "source folder is not a dirctory");
        try
        {
            var folderName = Path.GetFileName(sourceFolder);
            var destFolderDir = Path.Combine(destFolder, folderName);
            var fileNames = Directory.GetFileSystemEntries(sourceFolder);
            foreach (var fileName in fileNames)
            {
                if (Directory.Exists(fileName))
                {
                    var currentDir = Path.Combine(destFolderDir, Path.GetFileName(fileName));
                    if (Directory.Exists(currentDir))
                    {
                        Directory.CreateDirectory(currentDir);
                    }

                    CopyDirectory(fileName, destFolderDir);
                }
                else
                {
                    var srcFileName = Path.Combine(destFolderDir, Path.GetFileName(fileName));
                    if (!Directory.Exists(destFolderDir))
                    {
                        Directory.CreateDirectory(destFolderDir);
                    }
                    File.Copy(fileName, srcFileName);
                }
            }
        }
        catch (Exception e)
        {
            return new FileOperationResult(false, null, e.ToString());
        }
        return new FileOperationResult(true, null, "Copy folder success");
    }
}
