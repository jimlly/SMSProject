using System.Collections.Generic;
using SMS.Model.Addr;
using SMS.Model.Result;
using Public.Result;

namespace SMS.IDAL
{
    public interface IContactorGroupDAL
    {
        ResultContactorGroupList GetGroups(int userId, int compId, int pageIndex, int pageSize, string search);
        BaseResult AddGroup(int userId, string groupName, int compId);
        BaseResult SetGroupName(int userId, int groupID, string groupName, int compId);
        BaseResult DelGroups(int userId, List<ContactorGroup> groups, int compId);
        BaseResult CopyContactorsToOtherGroups(int userId, List<ContactorGroup> groups, List<Contactor> contactors, int compId);
        BaseResult RemoveContactors(int userId, List<ContactorGroup> groups, List<Contactor> contactors, int compId);
        ResultContactorList GetAllContactors(int userId, int compId, int pageIndex, int pageSize, string searchContent);
        ResultContactorList GetUnGroupedContactors(int userId, int compId, int pageIndex, int pageSize, string searchContent);
        ResultContactorList GetUserGroupContactors(int userId, int groupID, int compId, int pageIndex, int pageSize, string searchContent);
        BaseResult GetContactorsCount(int userId, int groupID, int compId, string searchContent);
    }
}
