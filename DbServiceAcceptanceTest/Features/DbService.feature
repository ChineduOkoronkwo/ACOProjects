@dbservice
Feature: DbService

Background:
    Given the following ProductBrand
        | id                                   |   name  |
        | 75f5b5b2-3776-43be-961d-648760142b09 |   Addidas    |
        | 559811ea-bf26-466c-b23c-f2bfc17f6b33 |    Apple     |
        | f31164a1-dd18-4c2c-89e4-bbc824471576 |   Google     |
        | a00a8ef8-28b9-49f3-b056-fe330ce4aac6 |  Instant Pot |

Scenario: Use ListAsync to fetch ProductBrands
    When I call ListAsync on ProductBrand with <sqlCommand>
    Then the ProductBrand details should match what was created

    Examples:
        | sqlCommand                    |
        | SELECT * FROM product_brands; |

Scenario: Use GetAsync to fetch a brand
    When I call GetAsync with the <sqlCommand> and <id>
    Then the ProductBrand should have <id> and <name>

    Examples:
        | sqlCommand                                   | id                                   |   name       |
        | SELECT * FROM product_brands WHERE id = @id; | 75f5b5b2-3776-43be-961d-648760142b09 |   Addidas    |
        | SELECT * FROM product_brands WHERE id = @id; | 559811ea-bf26-466c-b23c-f2bfc17f6b33 |    Apple     |
        | SELECT * FROM product_brands WHERE id = @id; | f31164a1-dd18-4c2c-89e4-bbc824471576 |   Google     |
        | SELECT * FROM product_brands WHERE id = @id; | a00a8ef8-28b9-49f3-b056-fe330ce4aac6 |  Instant Pot |