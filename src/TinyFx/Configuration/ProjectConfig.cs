using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TinyFx.Configuration
{
    /// <summary>
    /// Project模块配置节信息
    /// </summary>
    public class ProjectConfig : TinyFxConfiguration
    {
        /// <summary>
        /// 配置节名称
        /// </summary>
        /// <returns></returns>
        public override string GetConfigName()
            => "project";
        /// <summary>
        /// 项目标识
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 项目描述
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 默认Logger配置：log4net中配置的logger name
        /// </summary>
        public string Logger { get; set; }

        /// <summary>
        /// 当前程序运行环境
        /// </summary>
        public RunningEnvironment Running { get; set; } = RunningEnvironment.Unknown;

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="element"></param>
        public override void Parse(XmlElement element)
        {
            if (element == null) return;
            Id = GetAttributeValue(element, "id");
            Desc = GetAttributeValue(element, "desc"); 
            Logger = GetAttributeValue(element, "logger");
            var running = GetAttributeValue(element, "running")?.ToLower();
            switch (running)
            {
                case "debug":
                case "dev":
                case "development":
                    Running = RunningEnvironment.Development;
                    break;
                case "test":
                    Running = RunningEnvironment.Test;
                    break;
                case "sim":
                case "simulation":
                    Running = RunningEnvironment.Simulation;
                    break;
                case "release":
                case "online":
                    Running = RunningEnvironment.Online;
                    break;
                default:
                    Running = RunningEnvironment.Unknown;
                    break;
            }
        }
    }
}
