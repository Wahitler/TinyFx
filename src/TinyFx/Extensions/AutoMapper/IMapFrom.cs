﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyFx.Extensions.AutoMapper
{
    /// <summary>
    /// T类对象映射到当前类对象，不实现MapFrom则使用AutoMapper默认映射方法
    /// T ==> Entry
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMapFrom<T>
    {
        /// <summary>
        /// 实现从T类型对象src构建当前对象
        /// </summary>
        /// <param name="src"></param>
        void MapFrom(T src);
    }

    /// <summary>
    /// 从T1,T2类映射到当前类，不实现MapFrom则使用AutoMapper默认映射方法
    /// T ==> Entry
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public interface IMapFrom<T1, T2>
    {
        /// <summary>
        /// 实现从T1类型对象src构建当前对象
        /// </summary>
        /// <param name="src"></param>
        void MapFrom(T1 src);
        
        /// <summary>
        /// 实现从T2类型对象src构建当前对象
        /// </summary>
        /// <param name="src"></param>
        void MapFrom(T2 src);
    }

    /// <summary>
    /// 从T1,T2,T3类映射到当前类，不实现MapFrom则使用AutoMapper默认映射方法
    /// T ==> Entry
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    public interface IMapFrom<T1, T2, T3> : IMapFrom<T1, T2>
    {
        /// <summary>
        /// 实现从T3类型对象src构建当前对象
        /// </summary>
        /// <param name="src"></param>
        void MapFrom(T3 src);
    }

    /// <summary>
    /// 从T1,T2,T3, T4类映射到当前类，不实现MapFrom则使用AutoMapper默认映射方法
    /// T ==> Entry
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    public interface IMapFrom<T1, T2, T3, T4> : IMapFrom<T1, T2, T3>
    {
        /// <summary>
        /// 实现从T4类型对象src构建当前对象
        /// </summary>
        /// <param name="src"></param>
        void MapFrom(T4 src);
    }

    /// <summary>
    /// 从T1,T2,T3,T4,T5类映射到当前类，不实现MapFrom则使用AutoMapper默认映射方法
    /// T ==> Entry
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    public interface IMapFrom<T1, T2, T3, T4, T5> : IMapFrom<T1, T2, T3, T4>
    {
        /// <summary>
        /// 实现从T5类型对象src构建当前对象
        /// </summary>
        /// <param name="src"></param>
        void MapFrom(T5 src);
    }
}
