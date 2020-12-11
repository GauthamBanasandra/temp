public class PersonCollection {
    // Stores person
    public void add(Person person) {
    }

    // Prints all people in alphabetical order
    public void print() {
    }

    public static void main(String[] args) {
        PersonCollection people = new PersonCollection();

        Person akshatha = new Person("Akshatha", 24, Gender.kFemale);
        Person gautham = new Person("Gautham", 26, Gender.kMale);

        people.add(gautham);
        people.add(akshatha);

        people.print();
    }
}
