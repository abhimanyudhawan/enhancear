import amazonproduct
config = {
    'access_key': 'AKIAJ7KZ2EQ6G2SKWQVA',
    'secret_key': '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',
    'associate_tag': 'kartcrusher-20',
    'locale': 'us'
}
api = amazonproduct.API(cfg=config)
# get all books from result set and
# print author and title
for book in api.item_search('Books', Publisher='Galileo Press'):
    print '%s: "%s"' % (book.ItemAttributes.Author,
                        book.ItemAttributes.Title)
