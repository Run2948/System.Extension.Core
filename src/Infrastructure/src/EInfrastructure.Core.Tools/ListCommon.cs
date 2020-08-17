﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using EInfrastructure.Core.Config.Entities.Data;
using EInfrastructure.Core.Config.Entities.Ioc;
using EInfrastructure.Core.Configuration.Enumerations;
using EInfrastructure.Core.Configuration.Exception;

namespace EInfrastructure.Core.Tools
{
    /// <summary>
    /// List操作帮助类
    /// </summary>
    public static class ListCommon
    {
        #region List<T>操作

        #region List实体减法操作，从集合1中去除集合2的内容

        /// <summary>
        /// List实体减法操作
        /// 从集合1中去除集合2的内容
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t1">集合1（新集合）</param>
        /// <param name="t2">集合2（旧集合）</param>
        /// <returns>排除t1中包含t2的项</returns>
        public static List<T> ExceptNew<T>(this IEnumerable<T> t1, IEnumerable<T> t2)
        {
            return t1.Except(t2).ToList();
        }

        #endregion

        #region 获取t1与t2的相同项（交集）

        /// <summary>
        /// 获取t1与t2的相同项（交集）
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> IntersectNew<T>(this IEnumerable<T> t1, IEnumerable<T> t2)
        {
            return t1.Intersect(t2).ToList();
        }

        #endregion

        #region 连接t1,t2集合，自动过滤相同项

        /// <summary>
        /// 连接t1,t2集合，自动过滤相同项
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> UnionNew<T>(this IEnumerable<T> t1, IEnumerable<T> t2)
        {
            return t1.Union(t2).ToList();
        }

        #endregion

        #region 连接t1,t2集合，不会自动过滤相同项

        /// <summary>
        /// 连接t1,t2集合，不会自动过滤相同项
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> ConcatNew<T>(this IEnumerable<T> t1, IEnumerable<T> t2)
        {
            return t1.Concat(t2).ToList();
        }

        #endregion

        #region 两个集合计较

        /// <summary>
        /// 两个集合计较
        /// </summary>
        /// <param name="sourceList">源集合</param>
        /// <param name="optList">新集合</param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static ListCompare<T, TKey> CompareNew<T, TKey>(this List<T> sourceList, List<T> optList)
            where T : IEntity<TKey> where TKey : struct
        {
            return new ListCompare<T, TKey>(sourceList, optList);
        }

        /// <summary>
        /// 两个集合计较
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ListCompare<T, string> CompareNew<T>(this List<T> sourceList, List<T> optList)
            where T : IEntity<string>
        {
            return new ListCompare<T, string>(sourceList, optList);
        }

        #endregion

        #endregion

        #region List转String

        #region List转换为string

        /// <summary>
        /// List转换为string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str">待转换的list集合</param>
        /// <param name="split">分割字符</param>
        /// <param name="isReplaceEmpty">是否移除Null或者空字符串</param>
        /// <param name="isReplaceSpace">是否去除空格(仅当为string有效)</param>
        /// <returns></returns>
        public static string ConvertListToString<T>(this IEnumerable<T> str, char split = ',',
            bool isReplaceEmpty = true,
            bool isReplaceSpace = true) where T : struct
        {
            return str.ConvertListToString(split + "", isReplaceEmpty, isReplaceSpace);
        }

        /// <summary>
        /// List转换为string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str">待转换的list集合</param>
        /// <param name="split">分割字符</param>
        /// <param name="isReplaceEmpty">是否移除Null或者空字符串</param>
        /// <param name="isReplaceSpace">是否去除空格(仅当为string有效)</param>
        /// <returns></returns>
        public static string ConvertListToString<T>(this IEnumerable<T> str, string split = ",",
            bool isReplaceEmpty = true,
            bool isReplaceSpace = true) where T : struct
        {
            if (str == null || str.ToList().Count == 0)
            {
                return "";
            }

            return ConvertListToString(str.Select(x => x.ToString()).ToList(), split, isReplaceEmpty, isReplaceSpace);
        }

        #endregion

        #region List转换为string

        /// <summary>
        /// List转换为string
        /// </summary>
        /// <param name="str">待转换的list集合</param>
        /// <param name="split">分割字符</param>
        /// <param name="isReplaceEmpty">是否移除Null或者空字符串</param>
        /// <param name="isReplaceSpace">是否去除空格(仅当为string有效)</param>
        /// <returns></returns>
        public static string ConvertListToString(this IEnumerable<string> str, char split = ',',
            bool isReplaceEmpty = true,
            bool isReplaceSpace = true)
        {
            return str.ConvertListToString(split + "", isReplaceEmpty, isReplaceSpace);
        }

        /// <summary>
        /// List转换为string
        /// </summary>
        /// <param name="str">待转换的list集合</param>
        /// <param name="split">分割字符</param>
        /// <param name="isReplaceEmpty">是否移除Null或者空字符串</param>
        /// <param name="isReplaceSpace">是否去除空格(仅当为string有效)</param>
        /// <returns></returns>
        public static string ConvertListToString(this IEnumerable<string> str, string split = ",",
            bool isReplaceEmpty = true,
            bool isReplaceSpace = true)
        {
            if (str == null || !str.Any())
            {
                return "";
            }

            IEnumerable<string> tempList = str.ToList();
            if (isReplaceEmpty)
            {
                if (isReplaceSpace)
                {
                    tempList = tempList.Select(x => x.Trim());
                }

                tempList = tempList.Where(x => !string.IsNullOrEmpty(x));
            }

            return string.Join(split + "", tempList);
        }

        #endregion

        #region 字符串数组转String(简单转换)

        /// <summary>
        /// 字符串数组转String(简单转换)
        /// </summary>
        /// <param name="s">带转换的list集合</param>
        /// <param name="c">分割字符</param>
        /// <param name="isReplaceEmpty">是否移除Null或者空字符串</param>
        /// <param name="isReplaceSpace">是否去除空格(仅当为string有效)</param>
        /// <returns></returns>
        public static string ConvertListToString(this string[] s, char c = ',', bool isReplaceEmpty = true,
            bool isReplaceSpace = true)
        {
            if (s == null || s.Length == 0)
            {
                return "";
            }

            return ConvertListToString(s.ToList(), c, isReplaceEmpty, isReplaceSpace);
        }

        #endregion

        #endregion

        #region 对list集合分页

        /// <summary>
        /// 对list集合分页
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageSize">页码</param>
        /// <param name="pageIndex">页大小</param>
        /// <param name="isTotal">是否计算总条数</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static PageData<T> ListPager<T>(this ICollection<T> query, int pageSize, int pageIndex, bool isTotal)
        {
            PageData<T> list = new PageData<T>();

            if (isTotal)
            {
                list.RowCount = query.Count();
            }

            if (pageIndex - 1 < 0)
            {
                throw new BusinessException("页码必须大于等于1", HttpStatus.Err.Id);
            }

            query = query.Skip((pageIndex - 1) * pageSize).ToList();
            if (pageSize > 0)
            {
                list.Data = query.Take(pageSize).ToList();
            }
            else if (pageSize != -1)
            {
                throw new BusinessException("页大小须等于-1或者大于0", HttpStatus.Err.Id);
            }
            else
            {
                list.Data = query.ToList();
            }

            return list;
        }

        /// <summary>
        /// 对list集合分页执行某个方法
        /// </summary>
        /// <param name="query"></param>
        /// <param name="action"></param>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">当前页数（默认第一页）</param>
        /// <param name="errCode">错误码</param>
        /// <typeparam name="T"></typeparam>
        public static void ListPager<T>(this ICollection<T> query, Action<List<T>> action, int pageSize = -1,
            int pageIndex = 1, int? errCode = null)
        {
            if (pageSize <= 0 && pageSize != -1)
            {
                throw new BusinessException("页大小必须为正数", errCode ?? HttpStatus.Err.Id);
            }

            var totalCount = query.Count * 1.0d;
            int pageMax = 1;
            if (pageSize != -1)
            {
                pageMax = Math.Ceiling(totalCount / pageSize).ConvertToInt(1);
            }
            else
            {
                pageSize = totalCount.ConvertToInt(0) * 1;
            }

            for (int index = pageIndex; index <= pageMax; index++)
            {
                action(query.Skip((index - 1) * pageSize).Take(pageSize).ToList());
            }
        }

        /// <summary>
        /// 添加linq查询扩展(仅在Debug下生效)
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="logName">日志名称</param>
        /// <param name="logMethod">输出日志</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> LogLinq<T>(this IEnumerable<T> enumerable, string logName,
            Func<T, string> logMethod)
        {
#if DEBUG
            int count = 0;
            foreach (var item in enumerable)
            {
                if (logMethod != null)
                {
                    Debug.WriteLine($"{logName}|item {count} = {logMethod(item)}");
                }

                count++;
                yield return item;
            }

            Debug.WriteLine($"{logName}|count = {count}");
#else
            return enumerable;
#endif
        }

        #endregion

        #region 返回集合原来的第一个元素的值

        /// <summary>
        /// 返回集合原来的第一个元素的值,list集合中移除第一个值
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>返回集合原来的第一个元素的值</returns>
        public static T Shift<T>(this List<T> list)
        {
            if (list.Count == 0)
            {
                return default(T);
            }
            T res = list[0];
            list = list.Skip(1).ToList();
            return res;
        }

        #endregion

        #region 添加单个对象

        /// <summary>
        /// 添加单个对象
        /// </summary>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> AddNew<T>(this List<T> list, T item)
        {
            list.Add(item);
            return list;
        }

        #endregion

        #region 添加多个集合

        /// <summary>
        /// 添加多个集合
        /// </summary>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> AddNewMult<T>(this List<T> list, List<T> item)
        {
            list.AddRange(item);
            return list;
        }

        #endregion

        #region 移除

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static void RemoveNew<T>(this List<T> list, T item)
        {
            list.Remove(item);
        }

        /// <summary>
        /// 移除集合
        /// </summary>
        /// <param name="list">源集合</param>
        /// <param name="delList">待删除的集合</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static void RemoveRangeNew<T>(this List<T> list, ICollection<T> delList)
        {
            delList.ToList().ForEach(item => { list.Remove(item); });
        }

        #endregion

        #region 按条件移除

        #region 移除单条符合条件的数据

        /// <summary>
        /// 移除单条符合条件的数据
        /// </summary>
        /// <param name="list">源集合</param>
        /// <param name="condtion">条件</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static void RemoveNew<T>(this List<T> list, Expression<Func<T, bool>> condtion)
        {
            var item = list.FirstOrDefault(condtion.Compile());
            list.RemoveNew(item);
        }

        #endregion

        #region 移除多条满足条件

        /// <summary>
        /// 移除多条满足条件
        /// </summary>
        /// <param name="list"></param>
        /// <param name="condtion">条件</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static void RemoveRangeNew<T>(this List<T> list, Expression<Func<T, bool>> condtion)
        {
            var items = list.Where(condtion.Compile()).ToList();
            list.RemoveRangeNew(items);
        }

        #endregion

        #endregion

        /// <summary>
        ///
        /// </summary>
        public class ListCompare<T, TKey> where T : IEntity<TKey>
        {
            /// <summary>
            /// 初始化列表比较结果
            /// </summary>
            /// <param name="sourceList">原列表</param>
            /// <param name="optList">新列表</param>
            public ListCompare(List<T> sourceList, List<T> optList)
            {
                SourceList = sourceList ?? new List<T>();
                OptList = optList ?? new List<T>();
            }

            /// <summary>
            /// 原列表
            /// </summary>
            private IEnumerable<T> SourceList { get; }

            /// <summary>
            /// 新列表
            /// </summary>
            private IEnumerable<T> OptList { get; }

            #region 创建列表

            private List<T> _createList;

            /// <summary>
            /// 创建列表
            /// </summary>
            public List<T> CreateList => _createList ?? (_createList =
                OptList.Where(x => !
                        SourceList.Select(source => source.Id).ToList().Contains(x.Id))
                    .ToList());

            #endregion

            #region 更新列表

            private List<T> _updateList;

            /// <summary>
            /// 更新列表
            /// </summary>
            public List<T> UpdateList => _updateList ??
                                         (_updateList = SourceList.Where(x =>
                                                 OptList.Select(source => source.Id).ToList().Contains(x.Id))
                                             .ToList());

            #endregion

            #region 删除列表

            private List<T> _deleteList;

            /// <summary>
            /// 删除列表
            /// </summary>
            public List<T> DeleteList => _deleteList ??
                                         (_deleteList =
                                             SourceList.Where(x => !
                                                     OptList.Select(source => source.Id).ToList().Contains(x.Id))
                                                 .ToList());

            #endregion
        }
    }
}
