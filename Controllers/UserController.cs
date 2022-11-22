using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entity;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public UserController(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            //List<UserModel> users = _databaseContext.Users.ToList().Select(x => _mapper.Map<UserModel>(x)).ToList();


            List<User> users = _databaseContext.Users.ToList();
            List<UserModel> model = users.Select(x => _mapper.Map<UserModel>(x)).ToList();



            //foreach (User user in users)
            //{
            //    model.Add(new UserModel
            //    {
            //        FullName = user.FullName,                 İLK YÖNTEM
            //        Id = user.Id,
            //    });
            //}

            //_databaseContext.Users.Select(x => new UserModel { Id = x.Id, FullName = x.FullName }).ToList(); İKİNCİ YÖNTEM

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Users.Any(x => x.Username.ToLower() == model.Username.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.Username), "Username is already exist.");
                    return View(model);
                }

                User user = _mapper.Map<User>(model);

                _databaseContext.Users.Add(user);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Edit(Guid id)
        {
            User user = _databaseContext.Users.Find(id);
            EditUserModel model = _mapper.Map<EditUserModel>(user);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, EditUserModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Users.Any(x => x.Username.ToLower() == model.Username.ToLower() && x.Id != id))
                {
                    ModelState.AddModelError(nameof(model.Username), "Username is already exist.");
                    return View(model);
                }


                User user = _databaseContext.Users.Find(id);

                _mapper.Map(model, user);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        
        public IActionResult Delete(Guid id)
        { 
            User user = _databaseContext.Users.Find(id);

            if (user != null)
            {
                _databaseContext.Users.Remove(user);
                _databaseContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
