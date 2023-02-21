using System;
using Task3.DoNotChange;
using Task3.Exceptions;

namespace Task3
{
    public class UserTaskController
    {
        private readonly UserTaskService _taskService;

        public UserTaskController(UserTaskService taskService)
        {
            _taskService = taskService;
        }

        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            try
            {
                GetMessageForModel(userId, description);
            }
            catch (ArgumentException e)
            {
                model.AddAttribute("action_result", e.Message);
                return false;
            }
            catch (UserNotFoundException e)
            {
                model.AddAttribute("action_result", e.Message);
                // specified exception allows to use: e.UserId
                return false;
            }
            catch (TaskAlreadyExistException e)
            {
                model.AddAttribute("action_result", e.Message);
                // specified exception allows to use: e.Task
                return false;
            }

            return true;
        }

        private void GetMessageForModel(int userId, string description)
        {
            var task = new UserTask(description);
            _taskService.AddTaskForUser(userId, task);
        }
    }
}