﻿using System.Collections.Generic;

namespace XCLCMS.Data.BLL
{
    /// <summary>
    /// 所有附件关系表
    /// </summary>
    public partial class ObjectAttachment
    {
        private readonly XCLCMS.Data.DAL.ObjectAttachment dal = new XCLCMS.Data.DAL.ObjectAttachment();

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.ObjectAttachment> GetModelList(string strWhere)
        {
            return dal.GetModelList(strWhere);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        public bool Delete(XCLCMS.Data.CommonHelper.EnumType.ObjectTypeEnum objectType, long objectID)
        {
            return dal.Delete(objectType, objectID);
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        public bool Add(List<XCLCMS.Data.Model.ObjectAttachment> lst)
        {
            return dal.Add(lst);
        }

        /// <summary>
        /// 批量添加（先删再加）
        /// </summary>
        public bool Add(XCLCMS.Data.CommonHelper.EnumType.ObjectTypeEnum objectType, long objectID, List<long> attachmentIDList, XCLCMS.Data.Model.Custom.ContextModel context = null)
        {
            return dal.Add(objectType, objectID, attachmentIDList, context);
        }

        /// <summary>
        /// 返回指定类型的附件列表
        /// </summary>
        public List<XCLCMS.Data.Model.ObjectAttachment> GetModelList(XCLCMS.Data.CommonHelper.EnumType.ObjectTypeEnum objectType, long objectID)
        {
            return dal.GetModelList(objectType, objectID);
        }
    }
}