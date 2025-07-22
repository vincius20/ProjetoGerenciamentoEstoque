using ServicesContracts.DTO;

namespace ServicesContracts
{
    /// <summary>
    /// Bussiness logic for Category
    /// </summary>
    public interface ICategoriesService
    {
        /// <summary>
        /// Adds a category object to the list of categories
        /// </summary>
        /// <param name="categoryAddRequest">Category object to add</param>
        /// <returns>Category object response after adding it</returns>
        Task<CategoryResponse> AddCategory(CategoryAddRequest? categoryAddRequest);
        
        /// <summary>
        /// Gets all categories objects from the list of categories
        /// </summary>
        /// <returns>List of all categories response object</returns>
        Task<List<CategoryResponse>?> GetAllCategories();
        
        /// <summary>
        /// Get a category object from the id
        /// </summary>
        /// <param name="categoryId">The id of the required category</param>
        /// <returns>The category response object</returns>
        Task<CategoryResponse?> GetCategoryById(Guid? categoryId);

        /// <summary>
        /// Get a category object from the name
        /// </summary>
        /// <param name="categoryName">The name of the required category</param>
        /// <returns>The category response object</returns>
        Task<CategoryResponse?> GetCategoryByName(string? categoryName);

        /// <summary>
        /// Deletes the category
        /// </summary>
        /// <param name="categoryId">The id of the category which is going to be deleted</param>
        /// <returns>True if was excluded, False if it was not excluded</returns>
        Task<bool> DeleteCategory(Guid? categoryId);
    }
}
