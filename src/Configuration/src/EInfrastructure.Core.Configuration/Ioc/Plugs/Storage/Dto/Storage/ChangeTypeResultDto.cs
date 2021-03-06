﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace EInfrastructure.Core.Configuration.Ioc.Plugs.Storage.Dto.Storage
{
    /// <summary>
    /// 修改文件存储类型响应
    /// </summary>
    public class ChangeTypeResultDto : OperateResultDto
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="state"></param>
        /// <param name="key">文件key</param>
        /// <param name="msg"></param>
        public ChangeTypeResultDto(bool state, string key, string msg) : base(state, msg)
        {
            Key = key;
        }

        /// <summary>
        /// 文件key
        /// </summary>
        public string Key { get; set; }
    }
}
