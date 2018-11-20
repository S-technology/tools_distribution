using S_;
using u_functions;

// cделать зачистку всех объектов
namespace PM.Entity
{
    /// <summary>
    /// PM_entity_collection
    /// </summary>
    public class ec
    {
        SrRExecutiveEntity FE_SREX = null;
        /// <summary>
        /// Исполнитель
        /// </summary>
        public SrRExecutiveEntity E_SREX
        {
            get
            {
                if (FE_SREX == null || FE_SREX.Data == null
                    || !func.same_text(FE_SREX.Data.ConnectionName, s_DbConnection.CurrentConnectionName))
                {
                    FE_SREX = s_EntityObject.CreateObject("SrRExecutiveEntity", s_DbConnection.CurrentConnectionName)
                           as SrRExecutiveEntity;
                }
                return FE_SREX;
            }
        }

        /* шаблон
        xxxx_Entity FE_YYYY = null;
        /// <summary>
        /// entity
        /// </summary>
        public xxxx_Entity E_YYYY
        {
            get
            {
                if (FE_YYYY == null || FE_YYYY.Data == null
                    || !func.same_text(FE_YYYY.Data.ConnectionName, s_DbConnection.CurrentConnectionName))
                {
                    FE_YYYY = s_EntityObject.CreateObject("xxxx_Entity", s_DbConnection.CurrentConnectionName)
                           as xxxx_Entity;
                }
                return FE_YYYY;
            }
        }
        /**/

        SrRStatusEntity FE_SRST = null;
        /// <summary>
        /// Статус
        /// </summary>
        public SrRStatusEntity E_SRST
        {
            get
            {
                if (FE_SRST == null || FE_SRST.Data == null
                    || !func.same_text(FE_SRST.Data.ConnectionName, s_DbConnection.CurrentConnectionName))
                {
                    FE_SRST = s_EntityObject.CreateObject("SrRStatusEntity", s_DbConnection.CurrentConnectionName)
                           as SrRStatusEntity;
                }
                return FE_SRST;
            }
        }

        SrRPromptnessEntity FE_SRPR = null;
        /// <summary>
        /// срочность
        /// </summary>
        public SrRPromptnessEntity E_SRPR
        {
            get
            {
                if (FE_SRPR == null || FE_SRPR.Data == null
                    || !func.same_text(FE_SRPR.Data.ConnectionName, s_DbConnection.CurrentConnectionName))
                {
                    FE_SRPR = s_EntityObject.CreateObject("SrRPromptnessEntity", s_DbConnection.CurrentConnectionName)
                           as SrRPromptnessEntity;
                }
                return FE_SRPR;
            }
        }

    }
}
