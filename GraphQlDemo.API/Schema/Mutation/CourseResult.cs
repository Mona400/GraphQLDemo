﻿using GraphQlDemo.API.Models;

namespace GraphQlDemo.API.Schema.Mutation
{
    public class CourseResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public Guid InstructorId { get; set; }
    }
}
