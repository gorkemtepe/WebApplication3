using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entity;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MemberController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public MemberController(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MemberListPartial()
        {
            List<UserModel> users = _databaseContext.Users.ToList().Select(x => _mapper.Map<UserModel>(x)).ToList();
            return PartialView("_MemberListPartial", users);
        }
    }
}
