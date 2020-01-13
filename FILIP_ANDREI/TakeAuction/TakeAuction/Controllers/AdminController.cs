﻿using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TakeAuction.Models;

namespace TakeAuction.Controllers
{
    public class AdminController : Controller
    {
        public static SignIn usern;
        Connection conn = new Connection();
        // GET: Admin
        public ActionResult Index()
        {
            if (usern == null || ((usern != TempData["data"] as SignIn) && (TempData["data"] as SignIn != null)))
            {
                usern = TempData["data"] as SignIn;
            }
            return View();
        }

        public ActionResult Vizualizare()
        {
            ModelState.Clear(); //update la lista - actualizare
            return View(conn.GetLicitatii("select * from Licitatii")); //admin face select pe toate liciatiile + drepturi
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Licitatii licitatii)  // se creaza licitatii one by one
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    ViewBag.Text = conn.InsertLicitatii(licitatii, usern.User);
                }
                var factory = new ConnectionFactory()
                {
                    Uri = new Uri("amqp://urfkyisb:eaRpMrMI8FRa2G-MWzpOIdfEw6Y8-6ND@baboon.rmq.cloudamqp.com/urfkyisb"),
                    UserName = "urfkyisb",
                    Password = "eaRpMrMI8FRa2G-MWzpOIdfEw6Y8-6ND",
                };
                SendMessage(factory, licitatii);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Licitatii licitatii)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    ViewBag.Text = conn.EditLicitatii(licitatii);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(Licitatii licitatii)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    ViewBag.Text = conn.DeleteLicitatii(licitatii);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        private static void SendMessage(ConnectionFactory factory, Licitatii licitatii)
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "test", durable: false, exclusive: false, autoDelete: false, arguments: null);


                licitatii.User = usern.User;
                var json = JsonConvert.SerializeObject(licitatii);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "", routingKey: "test", basicProperties: null, body: body);
            }
        }
    }
}
