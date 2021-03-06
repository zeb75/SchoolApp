﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolApp.Models;

namespace SchoolApp.Controllers
{
    public class CoursesController : Controller
    {
        private SchoolAppDbContext db = new SchoolAppDbContext();

        // GET: Courses
        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Include("Students").Include("Teachers").Include("Assignments").SingleOrDefault(x => x.Id == id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult AddStudent(int cId)
        {
            List<Student> students = db.Students.ToList();
            ViewBag.cId = cId;
            return View(students);
        }
        [HttpGet]
        public ActionResult StudentToCourse(int sId, int cId)
        {
            Student student = db.Students.SingleOrDefault(s => s.Id == sId);

            Course course = db.Courses.Include("Students").SingleOrDefault(c => c.Id == cId);

            course.Students.Add(student);

            db.SaveChanges();

            return RedirectToAction("Details", new { id = cId });
        }

        [HttpGet]
        public ActionResult RemoveStudent(int cId)
        {
            List<Student> students = db.Students.ToList();
            ViewBag.cId = cId;
            return View(students);
        }
        [HttpGet]
        public ActionResult RemoveStudentFromCourse(int sId, int cId)
        {
            Student student = db.Students.SingleOrDefault(s => s.Id == sId);

            Course course = db.Courses.Include("Students").SingleOrDefault(c => c.Id == cId);

            course.Students.Remove(student);

            db.SaveChanges();

            return RedirectToAction("Details", new { id = cId });
        }

        [HttpGet]
        public ActionResult AddTeacher(int cId)
        {
            List<Teacher> teachers = db.Teachers.ToList();
            ViewBag.cId = cId;
            return View(teachers);
        }

        [HttpGet]
        public ActionResult TeacherToCourse(int tId, int cId)
        {
            Teacher teacher = db.Teachers.SingleOrDefault(t => t.Id == tId);

            Course course = db.Courses.Include("Teachers").SingleOrDefault(c => c.Id == cId);

            course.Teachers.Add(teacher);

            db.SaveChanges();

            return RedirectToAction("Details", new { id = cId });
        }

        [HttpGet]
        public ActionResult RemoveTeacher(int cId)
        {
            List<Teacher> teachers = db.Teachers.ToList();
            ViewBag.cId = cId;
            return View(teachers);
        }
        [HttpGet]
        public ActionResult RemoveTeacherFromCourse(int tId, int cId)
        {
            Teacher teacher = db.Teachers.SingleOrDefault(t => t.Id == tId);

            Course course = db.Courses.Include("Teachers").SingleOrDefault(c => c.Id == cId);

            course.Teachers.Remove(teacher);

            db.SaveChanges();

            return RedirectToAction("Details", new { id = cId });
        }

        [HttpGet]
        public ActionResult AddAssignment(int cId)
        {
            List<Assignment> assignments = db.Assignments.ToList();
            ViewBag.cId = cId;
            return View(assignments);
        }

        [HttpGet]
        public ActionResult AssignmentToCourse(int aId, int cId)
        {
            Assignment assignment = db.Assignments.SingleOrDefault(a => a.Id == aId);

            Course course = db.Courses.Include("Assignments").SingleOrDefault(c => c.Id == cId);

            course.Assignments.Add(assignment);

            db.SaveChanges();

            return RedirectToAction("Details", new { id = cId });
        }
        [HttpGet]
        public ActionResult RemoveAssignment(int cId)
        {
            List<Assignment> assignments = db.Assignments.ToList();
            ViewBag.cId = cId;
            return View(assignments);
        }
        [HttpGet]
        public ActionResult RemoveAssignmentFromCourse(int aId, int cId)
        {
            Assignment assignment = db.Assignments.SingleOrDefault(a => a.Id == aId);

            Course course = db.Courses.Include("Assignments").SingleOrDefault(c => c.Id == cId);

            course.Assignments.Remove(assignment);

            db.SaveChanges();

            return RedirectToAction("Details", new { id = cId });
        }

    }

}
