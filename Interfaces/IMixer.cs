interface IMixer
{
    public float MixEffect { get; set; }
    public void Mix();
    public void Mix(MealStorage mealStorage);
}