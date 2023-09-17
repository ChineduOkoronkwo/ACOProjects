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

Scenario: Use GetAsync to fetch a ProductBrand
    When I call GetAsync with the <id>
    Then the ProductBrand should have <id> and <name>

    Examples:
        | id                                   |   name       |
        | 75f5b5b2-3776-43be-961d-648760142b09 |   Addidas    |
        | 559811ea-bf26-466c-b23c-f2bfc17f6b33 |    Apple     |
        | f31164a1-dd18-4c2c-89e4-bbc824471576 |   Google     |
        | a00a8ef8-28b9-49f3-b056-fe330ce4aac6 |  Instant Pot |

Scenario: Use UpdateAsync to update ProductBrand
    When I call UpdateAsync with the <id> and <name>
    When I call GetAsync with the <id>
    Then the ProductBrand should have <id> and <name>

    Examples:
        | id                                   |     name      |
        | 75f5b5b2-3776-43be-961d-648760142b09 |     Pollo     |
        | 559811ea-bf26-466c-b23c-f2bfc17f6b33 | Swiss Challet |

# Scenario: Use DeleteAsync to delete a record on ProductBrand
#     When I call DeleteAsync with the <id>
#     And I Call ListAsync to fetch all ProductBrand
#     Then there should be only 3 records
#     And the will be no ProductBrand with the <id>

# Examples:
#         | id                                   |
#         | 75f5b5b2-3776-43be-961d-648760142b09 |
#         | 559811ea-bf26-466c-b23c-f2bfc17f6b33 |
#         | f31164a1-dd18-4c2c-89e4-bbc824471576 |
#         | a00a8ef8-28b9-49f3-b056-fe330ce4aac6 |