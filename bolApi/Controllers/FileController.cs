using Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace bolApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FileController : ApiBase
    {
        private const string FileDir = "/etc/loaddata/file";
        /// <summary>
        /// 缓冲式文件上传
        /// </summary>
        /// <returns></returns>
        [ActionName("upload")]
        public async Task<ApiReturn> Upload()
        {
            var files = Request.Form.Files;
            if (files.Count < 1)
                return ApiReturn.ParamaError;
            foreach (var file in files)
            {
                // 不要直接用文件的FileName作为保存的文件名,官方解释：
                /*  除了显示和日志记录用途外，请勿使用 IFormFile 的 FileName 属性。 显示或日志记录时，HTML 对文件名进行编码。 攻击者可以提供恶意文件名，包括完整路径或相对路径。 应用程序应：
                    从用户提供的文件名中删除路径。
                    为 UI 或日志记录保存经 HTML 编码、已删除路径的文件名。
                    生成新的随机文件名进行存储。
                */
                var fileTempName = Path.GetRandomFileName();
                var file_path = Path.Join(FileDir, fileTempName);
                using (FileStream stream = new FileStream(file_path, FileMode.Create, FileAccess.Write))
                {
                    await file.CopyToAsync(stream);
                } 
            }
            return ApiReturn.Succeed;
        }
        /// <summary>
        /// 流式文件上传
        /// </summary>
        /// <returns></returns>
        [ActionName("streamupload")]
        public async Task<ApiReturn> StreamUpload()
        {
            return ApiReturn.Succeed;
        }

        /// <summary>
        /// 流式文件上传
        /// </summary>
        /// <returns></returns>
        [ActionName("uploadchunk")]
        public async Task<ApiReturn> UploadChunk()
        {
            return ApiReturn.Succeed;
        }
    }
}
