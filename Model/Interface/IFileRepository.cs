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
    }
}
