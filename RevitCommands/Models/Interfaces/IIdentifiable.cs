using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.RevitCommands.Models.Interfaces
{
    /// <summary>
    /// 可识别对象的接口
    /// </summary>
    public interface IIdentifiable
    {
        /// <summary>
        /// 唯一标识符
        /// </summary>
        Guid Guid { get; }
    }
}