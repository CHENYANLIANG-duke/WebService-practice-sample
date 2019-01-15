using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    ///WebService1 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        private string GetRootPath()
        {
            return Path.GetFullPath(Server.MapPath("~"));
        }

        [WebMethod]
        public string HelloWorld()
        {
            string hello = "hello connection ok ";

            return hello;
        }

        /// <summary>
        /// 上傳檔案
        /// </summary>
        /// <param name="FileName">上傳的檔案名稱</param>
        /// <param name="bContext">檔案內容</param>
        /// <returns></returns>
        [WebMethod]
        public string UploadFile(string FileName, byte[] bContext)
        {
            string FilePath = Path.GetFullPath(Path.Combine(GetRootPath(), FileName));
            try
            {
                using (FileStream fs = new FileStream(FilePath, FileMode.Create))
                    fs.Write(bContext, 0, bContext.Length);
                return string.Format("檔案上傳到 {0}", FilePath);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 下傳檔案
        /// </summary>
        /// <param name="FileName">檔案名稱</param>
        /// <param name="bContext">檔案內容</param>
        /// <returns></returns>
        [WebMethod]
        public string DownFile(string FileName, out byte[] bContext)
        {
            bContext = null;
            string FilePath = Path.GetFullPath(Path.Combine(GetRootPath(), FileName));
            try
            {
                using (FileStream fs = new FileStream(FilePath, FileMode.Open))
                {
                    bContext = new byte[fs.Length];
                    fs.Read(bContext, 0, bContext.Length);
                }

                return string.Format("下傳{0}成功", FileName);
            }
            catch (FileNotFoundException ex)
            {
                return string.Format("找不到檔案 {0}\n{1}", FileName, ex.Message);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    



    }
}
