#!/usr/bin/env python
import sys
import digitalocean
import account

manager = digitalocean.Manager(token=account.token)

def destroy(droplet_id):
    droplet = manager.get_droplet(droplet_id)
    print "Found: {}".format(droplet.name)
    if len(droplet.tags) > 0:
        print "Tags found"
        if "production" in droplet.tags:
            print "This is a production droplet, will not delete it."
            sys.exit(1)
    print "Destroying"
    print droplet.destroy()


if __name__ == "__main__":
    if len(sys.argv) != 2:
        print "You must provide a droplet id as the first and only argument"
        sys.exit(1)
    droplet_id = sys.argv[1]
    destroy(droplet_id)
