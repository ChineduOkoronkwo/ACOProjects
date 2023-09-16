@dbservice
Feature: DbService

Background:
    Given the following ProductBrand
        | Id                                   |   Name  |
        | 75f5b5b2-3776-43be-961d-648760142b09 |   Addidas    |
        | 559811ea-bf26-466c-b23c-f2bfc17f6b33 |    Apple     |
        | f31164a1-dd18-4c2c-89e4-bbc824471576 |   Google     |
        | a00a8ef8-28b9-49f3-b056-fe330ce4aac6 |  Instant Pot |

Scenario: Use GetAsync to fetch all ProductBrand
    When I call GetAsync on ProductBrand with <sqlCommand>
    Then the ProductBrand details should match what was created

    Examples:
        | sqlCommand                    |
        | SELECT * FROM product_brands; |

# Scenario: Use GetSingleAsync to fetch each brands
#     When I call GetSingleAsync with the <sqlCommand> and <id> to fetch a single record
#     Then the ProductBrand should have <Id> and <BrandName>

#     Examples:
#         | Id                                   |   BrandName  |
#         | 75f5b5b2-3776-43be-961d-648760142b09 |   Addidas    |
#         | 559811ea-bf26-466c-b23c-f2bfc17f6b33 |    Apple     |
#         | f31164a1-dd18-4c2c-89e4-bbc824471576 |   Google     |
#         | a00a8ef8-28b9-49f3-b056-fe330ce4aac6 |  Instant Pot |