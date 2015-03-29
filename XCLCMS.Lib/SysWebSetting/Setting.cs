﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Lib.SysWebSetting
{
    /// <summary>
    /// 获取站点配置
    /// </summary>
    public class Setting
    {
        /// <summary>
        /// 所有配置
        /// </summary>
        private static List<XCLNetTools.PublicClass.KeyValue> AllSettings
        {
            get
            {
                List<XCLNetTools.PublicClass.KeyValue> lst = null;
                XCLCMS.Data.BLL.SysWebSetting bll = new Data.BLL.SysWebSetting();
                var settingList = bll.GetModelList(string.Format("RecordState='{0}'", XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString()));
                if (null != settingList && settingList.Count > 0)
                {
                    lst = new List<XCLNetTools.PublicClass.KeyValue>();
                    settingList.ForEach(m =>
                    {
                        lst.Add(new XCLNetTools.PublicClass.KeyValue()
                        {
                            Key = m.KeyName,
                            Value = m.KeyValue
                        });
                    });
                }
                return lst;            
            }
        }

        /// <summary>
        /// model形式的配置
        /// </summary>
        public static XCLCMS.Lib.SysWebSetting.SettingModel SettingModel
        {
            get
            {
                XCLCMS.Lib.SysWebSetting.SettingModel model = null;
                if (XCLNetTools.Cache.CacheClass.Exists(Lib.Common.Comm.SettingCacheName))
                {
                    //先从缓存读取
                    model = XCLNetTools.Cache.CacheClass.GetCache(Lib.Common.Comm.SettingCacheName) as XCLCMS.Lib.SysWebSetting.SettingModel;
                }
                if (null == model)
                {
                    //若缓存中没有，从数据库中读取
                    var all = Setting.AllSettings;
                    if (null != all && all.Count > 0)
                    {
                        model = new SettingModel();
                        var props = model.GetType().GetProperties();
                        if (null != props && props.Length > 0)
                        {
                            string propsName = string.Empty;
                            XCLNetTools.PublicClass.KeyValue tempKeyModel = null;
                            for (int i = 0; i < props.Length; i++)
                            {
                                propsName = props[i].Name;
                                tempKeyModel = all.Where(k => string.Equals(k.Key, string.Format("XCLCMS_{0}", propsName), StringComparison.OrdinalIgnoreCase)).First();
                                if (null != tempKeyModel)
                                {
                                    props[i].SetValue(model, tempKeyModel.Value);
                                }
                            }
                        }
                        XCLNetTools.Cache.CacheClass.SetCache(Lib.Common.Comm.SettingCacheName, model);
                    }
                }
                return model;            
            }
        }
    }
}