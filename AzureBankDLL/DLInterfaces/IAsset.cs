using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureBankDLL.BL;

namespace AzureBankDLL.DLInterfaces
{
    public interface IAsset
    {
        bool Create(Asset asset);
        List<Asset> ReadAll();
    }
}
