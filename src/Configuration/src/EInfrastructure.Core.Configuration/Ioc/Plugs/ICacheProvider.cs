﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EInfrastructure.Core.Configuration.Enumerations;

namespace EInfrastructure.Core.Configuration.Ioc.Plugs
{
    /// <summary>
    /// 缓存接口
    /// </summary>
    public interface ICacheProvider : ISingleInstance, IIdentify
    {
        #region String

        #region 同步方法

        /// <summary>
        /// 保存单个key value
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <param name="value">保存的值</param>
        /// <param name="expiry">过期时间</param>
        /// <param name="overdueStrategy"></param>
        /// <returns></returns>
        bool StringSet(string key, string value, TimeSpan? expiry = default(TimeSpan?),
            OverdueStrategy overdueStrategy = null);

        /// <summary>
        /// 保存一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="expiry"></param>
        /// <param name="overdueStrategy"></param>
        /// <returns></returns>
        bool StringSet<T>(string key, T obj, TimeSpan? expiry = default(TimeSpan?),
            OverdueStrategy overdueStrategy = null);

        /// <summary>
        /// 获取单个key的值
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <returns></returns>
        string StringGet(string key);

        /// <summary>
        /// 获取多个Key
        /// </summary>
        /// <param name="listKeys">Redis Key集合</param>
        /// <returns></returns>
        List<string> StringGet(List<string> listKeys);

        /// <summary>
        /// 获取一个key的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T StringGet<T>(string key) where T : class, new();

        /// <summary>
        /// 为数字增长val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val">可以为负</param>
        /// <returns>增长后的值</returns>
        long StringIncrement(string key, long val = 1);

        /// <summary>
        /// 为数字减少val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val">可以为负</param>
        /// <returns>减少后的值</returns>
        long StringDecrement(string key, long val = 1);

        #endregion 同步方法

        #region 异步方法

        /// <summary>
        /// 保存单个key value
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <param name="value">保存的值</param>
        /// <param name="expiry">过期时间</param>
        /// <param name="overdueStrategy"></param>
        /// <returns></returns>
        Task<bool> StringSetAsync(string key, string value, TimeSpan? expiry = default(TimeSpan?),
            OverdueStrategy overdueStrategy = null);

        /// <summary>
        /// 保存一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="expiry"></param>
        /// <param name="overdueStrategy"></param>
        /// <returns></returns>
        Task<bool> StringSetAsync<T>(string key, T obj, TimeSpan? expiry = default(TimeSpan?),
            OverdueStrategy overdueStrategy = null);

        /// <summary>
        /// 获取单个key的值
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <returns></returns>
        Task<string> StringGetAsync(string key);


        /// <summary>
        /// 为数字增长val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val">可以为负</param>
        /// <returns>增长后的值</returns>
        Task<long> StringIncrementAsync(string key, long val = 1);

        /// <summary>
        /// 为数字减少val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val">可以为负</param>
        /// <returns>减少后的值</returns>
        Task<long> StringDecrementAsync(string key, long val = 1);

        #endregion 异步方法

        #endregion String

        #region Hash

        #region 同步方法

        /// <summary>
        /// 判断某个数据是否已经被缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        bool HashExists(string key, string dataKey);

        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <param name="second">秒</param>
        /// <param name="isSetHashKeyExpire">false：设置key的过期时间（整个键使用一个过期时间），true：设置hashkey的过期时间，默认设置的为HashKey的过期时间（单个datakey使用一个过期时间）。</param>
        /// <param name="overdueStrategy"></param>
        /// <returns></returns>
        bool HashSet<T>(string key, string dataKey, T t, long second = -1L, bool isSetHashKeyExpire = true,
            OverdueStrategy overdueStrategy = null);

        /// <summary>
        ///  存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="kvalues"></param>
        /// <param name="second">秒</param>
        /// <param name="isSetHashKeyExpire">false：设置key的过期时间（整个键使用一个过期时间），true：设置hashkey的过期时间，默认设置的为HashKey的过期时间（单个datakey使用一个过期时间）。</param>
        /// <param name="overdueStrategy"></param>
        /// <returns></returns>
        bool HashSet<T>(string key, Dictionary<string, T> kvalues, long second = -1L, bool isSetHashKeyExpire = true,
            OverdueStrategy overdueStrategy = null);

        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <param name="kValues"></param>
        /// <param name="second"></param>
        /// <param name="isSetHashKeyExpire"></param>
        /// <param name="overdueStrategy"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        bool HashSet<T>(Dictionary<string, Dictionary<string, T>> kValues, long second = -1,
            bool isSetHashKeyExpire = true,
            OverdueStrategy overdueStrategy = null);

        /// <summary>
        /// 清除过期的hashkey(自定义hashkey删除)
        /// </summary>
        /// <param name="count">指定清除指定数量的已过期的hashkey</param>
        /// <returns></returns>
        bool ClearOverTimeHashKey(long count = 1000L);

        /// <summary>
        /// 移除hash中的某值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        bool HashDelete(string key, string dataKey);

        /// <summary>
        /// 移除hash中的多个值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKeys"></param>
        /// <returns></returns>
        long HashDelete(string key, List<string> dataKeys);

        /// <summary>
        /// 从hash表获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        T HashGet<T>(string key, string dataKey) where T : class, new();

        /// <summary>
        /// 从hash表获取数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        string HashGet(string key, string dataKey);

        /// <summary>
        /// 从hash表获取数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKeys"></param>
        /// <returns></returns>
        Dictionary<string, string> HashGet(string key, List<string> dataKeys);

        /// <summary>
        /// 从hash表获取数据
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        Dictionary<string, Dictionary<string, string>> HashGet(Dictionary<string, string[]> keys);

        /// <summary>
        /// 为数字增长val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="val">可以为负</param>
        /// <returns>增长后的值</returns>
        long HashIncrement(string key, string dataKey, long val = 1);

        /// <summary>
        /// 为数字减少val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="val">可以为负</param>
        /// <returns>减少后的值</returns>
        long HashDecrement(string key, string dataKey, long val = 1);

        /// <summary>
        /// 获取hashkey所有Redis key
        /// </summary>
        /// <param name="key">缓存key名称</param>
        /// <returns></returns>
        List<string> HashKeys(string key);

        #endregion 同步方法

        #region 异步方法

        /// <summary>
        /// 判断某个数据是否已经被缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        Task<bool> HashExistsAsync(string key, string dataKey);

        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="t"></param>
        /// <param name="overdueStrategy"></param>
        /// <returns></returns>
        Task<bool> HashSetAsync<T>(string key, string dataKey, T t,
            OverdueStrategy overdueStrategy = null);

        /// <summary>
        /// 移除hash中的某值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        Task<bool> HashDeleteAsync(string key, string dataKey);

        /// <summary>
        /// 移除hash中的多个值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKeys"></param>
        /// <returns></returns>
        Task<long> HashDeleteAsync(string key, List<string> dataKeys);

        /// <summary>
        /// 从hash表获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        Task<T> HashGetAsync<T>(string key, string dataKey) where T : class, new();

        /// <summary>
        /// 从hash表获取数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        Task<string> HashGetAsync(string key, string dataKey);

        /// <summary>
        /// 为数字增长val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="val">可以为负</param>
        /// <returns>增长后的值</returns>
        Task<long> HashIncrementAsync(string key, string dataKey, long val = 1);

        /// <summary>
        /// 为数字减少val
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataKey"></param>
        /// <param name="val">可以为负</param>
        /// <returns>减少后的值</returns>
        Task<long> HashDecrementAsync(string key, string dataKey, long val = 1);

        /// <summary>
        /// 获取hashkey所有Redis key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<List<string>> HashKeysAsync(string key);

        #endregion 异步方法

        #endregion Hash

        #region List

        #region 同步方法

        /// <summary>
        /// 移除指定ListId的内部List的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long ListRemove<T>(string key, T value);

        /// <summary>
        /// 获取指定key的List
        /// </summary>
        /// <param name="key"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<string> ListRange(string key, long count = 1000);

        /// <summary>
        /// 获取指定key的List
        /// </summary>
        /// <param name="key"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<T> ListRange<T>(string key, long count = 1000) where T : class, new();

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long ListRightPush<T>(string key, T value);

        /// <summary>
        /// 出队
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string ListRightPop(string key);

        /// <summary>
        /// 出队
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T ListRightPop<T>(string key) where T : class, new();

        /// <summary>
        /// 入栈
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        long ListLeftPush<T>(string key, T value);

        /// <summary>
        /// 出栈
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string ListLeftPop(string key);

        /// <summary>
        /// 出栈
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T ListLeftPop<T>(string key) where T : class, new();

        /// <summary>
        /// 获取集合中的数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        long ListLength(string key);

        #endregion 同步方法

        #region 异步方法

        /// <summary>
        /// 移除指定ListId的内部List的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<long> ListRemoveAsync<T>(string key, T value);

        /// <summary>
        /// 获取指定key的List
        /// </summary>
        /// <param name="key"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<List<string>> ListRangeAsync(string key, long count = 1000L);

        /// <summary>
        /// 获取指定key的List
        /// </summary>
        /// <param name="key"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<List<T>> ListRangeAsync<T>(string key, long count = 1000L) where T : class, new();

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<long> ListRightPushAsync<T>(string key, T value);

        /// <summary>
        /// 出队
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<string> ListRightPopAsync(string key);

        /// <summary>
        /// 出队
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<T> ListRightPopAsync<T>(string key) where T : class, new();

        /// <summary>
        /// 入栈
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<long> ListLeftPushAsync<T>(string key, T value);

        /// <summary>
        /// 出栈
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<string> ListLeftPopAsync(string key);

        /// <summary>
        /// 出栈
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<T> ListLeftPopAsync<T>(string key) where T : class, new();

        /// <summary>
        /// 获取集合中的数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<long> ListLengthAsync(string key);

        #endregion 异步方法

        #endregion List

        #region SortedSet 有序集合

        #region 同步方法

        /// <summary>
        /// 添加 (当score一样value一样时不插入)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        /// <param name="isOverlap"></param>
        /// <returns></returns>
        bool SortedSetAdd<T>(string key, T value, double score, bool isOverlap = false);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool SortedSetRemove<T>(string key, T value);

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <param name="key"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<string> SortedSetRangeByRank(string key, long count = 1000L);

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <param name="key"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<T> SortedSetRangeByRank<T>(string key, long count = 1000L) where T : class, new();

        /// <summary>
        /// 获取已过期的hashKey
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        List<ValueTuple<string, string, string, string>> SortedSetRangeByRankAndOverTime(long count = 1000L);

        /// <summary>
        /// 降序获取指定索引的集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="fromRank"></param>
        /// <param name="toRank"></param>
        /// <returns></returns>
        List<T> GetRangeFromSortedSetDesc<T>(string key, long fromRank, long toRank) where T : class, new();

        #region 获取指定索引的集合

        /// <summary>
        /// 获取指定索引的集合
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fromRank"></param>
        /// <param name="toRank"></param>
        /// <returns></returns>
        List<string> GetRangeFromSortedSet(string key, long fromRank, long toRank);

        /// <summary>
        /// 获取指定索引的集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="fromRank"></param>
        /// <param name="toRank"></param>
        /// <returns></returns>
        List<T> GetRangeFromSortedSet<T>(string key, long fromRank, long toRank) where T : class, new();

        #endregion

        /// <summary>
        /// 判断是否存在项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool SortedSetExistItem<T>(string key, T value);

        /// <summary>
        /// 获取集合中的数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        long SortedSetLength(string key);

        #endregion 同步方法

        #region 异步方法

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        Task<bool> SortedSetAddAsync<T>(string key, T value, double score);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<bool> SortedSetRemoveAsync<T>(string key, T value);

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <param name="key"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<List<string>> SortedSetRangeByRankAsync(string key, long count = 1000L);

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <param name="key"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<List<T>> SortedSetRangeByRankAsync<T>(string key, long count = 1000L) where T : class, new();

        /// <summary>
        /// 获取集合中的数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<long> SortedSetLengthAsync(string key);

        #endregion 异步方法

        #endregion SortedSet 有序集合

        #region Basics

        /// <summary>
        /// 删除指定Key的缓存
        /// 用于在 key 存在时删除 key
        /// </summary>
        /// <param name="keys">待删除的Key集合</param>
        /// <returns>返回删除的数量</returns>
        long Remove(List<string> keys);

        /// <summary>
        /// 删除指定Key的缓存
        /// 用于在 key 存在时删除 key
        /// </summary>
        /// <param name="keys">待删除的Key集合，不含prefix前辍RedisHelper.Name</param>
        /// <returns>返回删除的数量</returns>
        long Remove(params string[] keys);

        /// <summary>
        /// 检查给定 key 是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Exist(string key);

        /// <summary>
        /// 设置指定key过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expire">过期时间</param>
        /// <returns></returns>
        bool Expire(string key, TimeSpan expire);

        /// <summary>
        /// 查找所有符合给定模式( pattern)的 key
        /// </summary>
        /// <param name="pattern">如：runoob*</param>
        /// <returns></returns>
        List<string> Keys(string pattern);

        #endregion
    }
}
