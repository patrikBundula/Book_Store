using Database.Entity.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interface
{
    public interface IFileRepository
    {
        public Guid UploadFile(Stream stream, string fileName, Guid? fielId = null);
        public Stream GetFile(Guid fileId, uint? version = null);
        public FileStore GetFileInfo(Guid fileId, uint? version = null);
        public bool DeleteFile(Guid fileId, bool latest = true);
    }
}
