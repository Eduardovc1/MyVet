using Microsoft.AspNetCore.Identity;
using MyVet.Web.Data.Entities;
using MyVet.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;
       
        public SeedDb(DataContext context,IUserHelper userHelper)
        {
            _dataContext = context;
            _userHelper = userHelper;
           
        }
        public async  Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRoles();
            var manager = await CheckUserAsync("1010","Eduardo","Villarreal","eduardo@gmail.com","350 634 2747","9612337869","Dimicilio conocido","Admin");
            var customer= await CheckUserAsync("1010", "Eduardo", "Villarreal", "eduardo@hotmail.com", "350 634 2747","9612337869", "Dimicilio conocido", "Customer");
            await CheckPetTypesAsync();
            await CheckServiceTypeAsync();
            await CheckOwnerAsync(customer);
            await CheckManagerAsync(manager);
            await CheckPetAsync();
            await CheckAgendaAsync();


        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckroleAsync("Admin");
            await _userHelper.CheckroleAsync("Customer");
        }
        private async Task<User> CheckUserAsync(string document, string firtsName, string lastname, string email,
            string phone,string cellPhone ,string address,string role)
        {
            var user = await _userHelper.GetuserByEmailAsync(email);
            if (user==null)
            {
                user = new User
                {
                    FirstName = firtsName,
                    LastName = lastname,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    CellPhone=cellPhone
                    

                };
                await _userHelper.AddUserAsync(user,"123456");
                await _userHelper.AdduserToRoleAsync(user,role);
            }
            return user;
        }



        //private void AddOwner(string document,string firtsName,string lastname,string fixedPhone,string cellPhone,string address)
        //{
        //    _context.Owners.Add(new Owner { 
        //    Address=address,
        //    CellPhone=cellPhone,
        //    Document=document,
        //    FirstName=firtsName,
        //    LastName=lastname,
        //    FixedPhone=fixedPhone

        //    }              
        //        );
        //}
        private  async Task CheckAgendaAsync()
        {
            if (!_dataContext.Agendas.Any())
            {
                var initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,8,0,0);
                var finalDate = initialDate.AddYears(1);
                while(initialDate< finalDate)
                {
                    if (initialDate.DayOfWeek!=DayOfWeek.Sunday)
                    {
                        var finalDate2 = initialDate.AddHours(10);
                        while (initialDate< finalDate2)
                        {
                            _dataContext.Agendas.Add(new Agenda { 
                            Date=initialDate.ToUniversalTime(),
                            IsAvailable=true
                            
                            });
                            initialDate = initialDate.AddMinutes(30);
                        }
                        initialDate = initialDate.AddHours(14);
                    }else
                    {
                        initialDate = initialDate.AddDays(1);
                    }
                }
                await _dataContext.SaveChangesAsync();
            }

            
        }

        private async Task CheckPetAsync()
        {
            
            var owner = _dataContext.Owners.FirstOrDefault();
            var pepType = _dataContext.PepTypes.FirstOrDefault();
            if (!_dataContext.Pets.Any())
            {
                AddPet("Otto",owner,pepType,"Shih tzu");
                AddPet("Killer", owner, pepType, "Doberman");
                await _dataContext.SaveChangesAsync();
            }
        }
        private void AddPet(string name, Owner owner, PepType pepType, string race)
        {
            _dataContext.Pets.Add(new Pet
            {
                Born = DateTime.Now.AddYears(-2),
                Name=name,
                Owner=owner,
                PepType=pepType,
                Race=race

            }
                );
        }
        private async Task CheckOwnerAsync(User user)
        {
            if (!_dataContext.Owners.Any())
            {
                _dataContext.Owners.Add(new Owner {User=user });
                await _dataContext.SaveChangesAsync();
            }
           
        }

        private async Task CheckManagerAsync(User user)
        {
            if (_dataContext.Managers.Any())
            {
                _dataContext.Managers.Add(new Manager { User= user});
                await _dataContext.SaveChangesAsync();
            }
        }
        private async Task CheckServiceTypeAsync()
        {
            if (!_dataContext.ServiceTypes.Any())
            {
                _dataContext.ServiceTypes.Add(new ServiceType {Name="Consulta" });
                _dataContext.ServiceTypes.Add(new ServiceType { Name = "Urgencia" });
                _dataContext.ServiceTypes.Add(new ServiceType { Name = "Vacunación" });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckPetTypesAsync()
        {
           if (!_dataContext.PepTypes.Any())
            {
                _dataContext.PepTypes.Add(new PepType {Name="Perro" });
                _dataContext.PepTypes.Add(new PepType { Name = "Gato" });
               
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
