Here is what we did in this branch:

- Here, we implemented AutoMapper.
- This enables us to get rid of manually mapping objects between the domain and DTOs.
- It works by transforming an input object of one type (source) into an output object of another type (destination).
- With AutoMapper, we can define the mapping between domain and DTOs in a single place.
- AutoMapper does this by mapping properties with the same name by default.
- However, if the property names are different, we can specify the mapping explicitly by using the ForMember method.
- Using AutoMapper makes the code cleaner and easier to maintain.