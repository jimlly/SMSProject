using System.Collections.Generic;
using SMS.Model.Addr;
using SMS.Model.Result;
using Public.Result;

namespace SMS.IDAL
{
    public interface IContactorDAL
    {
        BaseResult AddContactor(int userId, Contactor contactor, int compId);
        BaseResult DelContactors(int userId, List<Contactor> contactors, int compId);
        BaseResult DelContactorsByGroup(int userId, List<Contactor> contactors, int compId, int groupId);
        ResultContactorDetail GetDetail(int userId, int contactorID, int compId);
        BaseResult SetContactorGroups(int userId, List<ContactorGroup> groups, int contactorID, int compId);
        BaseResult SetName(int userId, int contactorID, string name, int compId);
        BaseResult SetContactWay(int userId, int contactorID, List<ContactWay> cWay, int compId, string confParticipatePhoneNo);
   
    }
}
