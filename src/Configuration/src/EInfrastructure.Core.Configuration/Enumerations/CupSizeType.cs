// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using EInfrastructure.Core.Configuration.Enumerations.SeedWork;

namespace EInfrastructure.Core.Configuration.Enumerations
{
    /// <summary>
    /// 罩杯
    /// </summary>
    public class CupSize : Enumeration
    {
        /// <summary>
        /// 未知
        /// </summary>
        public static CupSize Unknow = new CupSize(1, "未知");

        /// <summary>
        /// 无
        /// </summary>
        public static CupSize None = new CupSize(2, "无");

        /// <summary>
        /// A杯
        /// </summary>
        public static CupSize A = new CupSize(6, "A杯");

        /// <summary>
        /// B杯
        /// </summary>
        public static CupSize B = new CupSize(4, "B杯");

        /// <summary>
        /// C杯
        /// </summary>
        public static CupSize C = new CupSize(5, "C杯");

        /// <summary>
        /// D杯
        /// </summary>
        public static CupSize D = new CupSize(6, "D杯");

        /// <summary>
        /// E杯
        /// </summary>
        public static CupSize E = new CupSize(7, "E杯");

        /// <summary>
        /// F杯
        /// </summary>
        public static CupSize F = new CupSize(8, "F杯");

        /// <summary>
        /// G杯
        /// </summary>
        public static CupSize G = new CupSize(9, "G杯");

        /// <summary>
        /// H杯
        /// </summary>
        public static CupSize H = new CupSize(10, "H杯");

        /// <summary>
        /// I杯
        /// </summary>
        public static CupSize I = new CupSize(11, "I杯");

        /// <summary>
        /// J杯
        /// </summary>
        public static CupSize J = new CupSize(12, "J杯");

        /// <summary>
        /// K杯
        /// </summary>
        public static CupSize K = new CupSize(13, "K杯");

        /// <summary>
        /// L杯
        /// </summary>
        public static CupSize L = new CupSize(14, "L杯");

        /// <summary>
        /// M杯
        /// </summary>
        public static CupSize M = new CupSize(15, "M杯");

        /// <summary>
        /// N杯
        /// </summary>
        public static CupSize N = new CupSize(16, "N杯");

        /// <summary>
        /// O杯
        /// </summary>
        public static CupSize O = new CupSize(17, "O杯");

        /// <summary>
        /// P杯
        /// </summary>
        public static CupSize P = new CupSize(18, "P杯");

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name">描述</param>
        public CupSize(int id, string name) : base(id, name)
        {
        }
    }
}
