using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WpfDemo.Models.Entity;
using WpfDemo.Utils;

namespace WpfDemo.Services
{
    public class StudentService
    {
        private readonly ILogger<StudentService> _logger;
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:5189/api";
        public StudentService(ILogger<StudentService> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new CustomDateTimeConverter() }
                };

                var response = await _httpClient.GetFromJsonAsync<ApiResponse<List<Student>>>(
                    $"{BaseUrl}/Students/GetStudentList", options);

                return response?.Data ?? new List<Student>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取学生数据失败");
                throw new Exception($"获取学生数据失败: {ex.Message}", ex);
            }
        }

        public async Task<Student?> GetStudentAsync(int id)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new CustomDateTimeConverter() }
                };
                var response = await _httpClient.GetFromJsonAsync<ApiResponse<Student>>($"{BaseUrl}/Students/GetStudent/{id}",options);
                return response?.Data ?? new Student();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取学生数据失败");
                throw new Exception($"获取学生信息失败: {ex.Message}", ex);
            }
        }

        public async Task<bool> AddStudentAsync(Student student)
        {
            try
            {
                var json = JsonSerializer.Serialize(student);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{BaseUrl}/Students/Create", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "添加学生数据失败");
                throw new Exception($"添加学生失败: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            try
            {
                var json = JsonSerializer.Serialize(student);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"{BaseUrl}/Students/UpdateUser/{student.Id}", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "更新学生数据失败");
                throw new Exception($"更新学生信息失败: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{BaseUrl}/Students/Delete/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "删除学生数据失败");
                throw new Exception($"删除学生失败: {ex.Message}", ex);
            }
        }
        public class ApiResponse<T>
        {
            public int Code { get; set; }
            public T Data { get; set; }
            public string Message { get; set; }
            public string Timestamp { get; set; }
        }
    }
}
