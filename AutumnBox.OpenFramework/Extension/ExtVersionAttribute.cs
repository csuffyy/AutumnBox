﻿/*************************************************
** auth： zsh2401@163.com
** date:  2018/8/1 20:41:03 (UTC +8:00)
** desc： ...
*************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutumnBox.OpenFramework.Extension
{
    /// <summary>
    /// 拓展模块版本号
    /// </summary>
    public class ExtVersionAttribute : ExtInfoAttribute
    {
        /// <summary>
        /// 构建
        /// </summary>
        /// <param name="major">主版本号</param>
        /// <param name="minor">辅版本号</param>
        /// <param name="build">构建号</param>
        public ExtVersionAttribute(int major, int minor, int build)
            : base(new Version(major, minor, build))
        {
        }
    }
}