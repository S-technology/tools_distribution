using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_; 
using IM.Functions;
using Entities;

namespace PM.Entity
{
    public class Class_Registration
    {
        /// <summary>
        /// зарегистрировать пару сущность + дата-класс
        /// </summary>
        /// <param name="DataObject_name"></param>
        /// <param name="EntityObject_name"></param>
        public static void RegAll(string DataObject_name, string EntityObject_name)
        {
            if (!String.IsNullOrEmpty(DataObject_name))
            {
                s_DataObject.Register(DataObject_name);
            }
            if (!String.IsNullOrEmpty(EntityObject_name))
            {
                s_EntityObject.Register(EntityObject_name);
            }
        }

        /// <summary>
        /// регистрация уже произошла
        /// </summary>
        public static bool is_registered = false;

        /// <summary>
        /// зарегистрировать все классы
        /// </summary>
        public static void Register()
        {
            //RegAll("PM.Entity.SrRStatusData, PM_Entities", "PM.Entity.SrRStatusEntity, PM_Entities");
            //RegAll("PM.Entity.SrRPromptnessData, PM_Entities", "PM.Entity.SrRPromptnessEntity, PM_Entities");
            //RegAll("PM.Entity.SrRProjectData, PM_Entities", "PM.Entity.SrRProjectEntity, PM_Entities");
            //RegAll("PM.Entity.SrRExecutiveData, PM_Entities", "PM.Entity.SrRExecutiveEntity, PM_Entities");
            //RegAll("PM.Entity.SrRemarkData, PM_Entities", "PM.Entity.SrRemarkEntity, PM_Entities");
            //RegAll("PM.Entity.SrDetailRemarkData, PM_Entities", "PM.Entity.SrDetailRemarkEntity, PM_Entities");

            //RegAll("Entities.DdObjectData, IM.CommonEntities", "Entities.DdObjectEntity, IM.CommonEntities");
            //RegAll("Entities.SEiData, IM.CommonEntities", "Entities.SEiEntity, IM.CommonEntities");
            //RegAll("Entities.RMeasureDsData, IM.CommonEntities", "Entities.RMeasureDsEntity, IM.CommonEntities");

            s_DataObject.Register(typeof(SrRStatusData));
            s_EntityObject.Register(typeof(SrRStatusEntity));

            s_DataObject.Register(typeof(SrRPromptnessData));
            s_EntityObject.Register(typeof(SrRPromptnessEntity));

            s_DataObject.Register(typeof(SrRProjectData));
            s_EntityObject.Register(typeof(SrRProjectEntity));

            s_DataObject.Register(typeof(SrRExecutiveData));
            s_EntityObject.Register(typeof(SrRExecutiveEntity));

            s_DataObject.Register(typeof(SrRemarkData));
            s_EntityObject.Register(typeof(SrRemarkEntity));

            s_DataObject.Register(typeof(SrDetailRemarkData));
            s_EntityObject.Register(typeof(SrDetailRemarkEntity));

            s_DataObject.Register(typeof(DdObjectData));
            s_EntityObject.Register(typeof(DdObjectEntity));

            s_DataObject.Register(typeof(SEiData));
            s_EntityObject.Register(typeof(SEiEntity));

            s_DataObject.Register(typeof(RMeasureDsData));
            s_EntityObject.Register(typeof(RMeasureDsEntity));

			s_DataObject.Register(typeof(SrFavoriteData));
			s_EntityObject.Register(typeof(SrFavoriteEntity));

            s_DataObject.Register(typeof(SrRClientData));
            s_EntityObject.Register(typeof(SrRClientEntity));

            s_DataObject.Register(typeof(SrPhysPersonData));
            s_EntityObject.Register(typeof(SrPhysPersonEntity));

            // ============== регистрация классов ====================

            //s_EntityObject.RegisterTable(s_DbConnection.CurrentConnectionName, "SR_PHYS_PERSON_SRPP", "SrPhysPersonData", "SrPhysPersonEntity", "PM", "IM.Hierarchy.GraphDataObject,IM.Hierarchy", "IM.Hierarchy.GraphEntity",
            //    "SR_PHYS_PERSON_SRPP_SEQ", "IM.Hierarchy");

            //s_EntityObject.RegisterTable(s_DbConnection.CurrentConnectionName, "SR_R_CLIENT_SRCL", "SrRClientData", "SrRClientEntity", "PM", "IM.Hierarchy.GraphDataObject,IM.Hierarchy", "IM.Hierarchy.GraphEntity", 
            //    "SR_R_CLIENT_SRCL_SEQ", "IM.Hierarchy");

            is_registered = true;
        }
    }
}
