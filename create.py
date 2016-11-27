#!/usr/bin/env python
import sys
import digitalocean
import account

manager = digitalocean.Manager(token=account.token)

def create(droplet_name):
    droplet = digitalocean.Droplet(token=account.token,
                                   name=droplet_name,
                                   region='fra1',  # Frankfurt 1
                                   image=20821869,
                                   size_slug='512mb',  # 512MB
                                   backups=True, ssh_keys=manager.get_all_sshkeys())
    droplet.create()

if __name__ == "__main__":
    if len(sys.argv) != 2:
        print "You must provide a droplet name as the first and only argument"
        sys.exit(1)
    droplet_name = sys.argv[1]
    create(droplet_name)
