#!/usr/bin/env python
import digitalocean
import account

manager = digitalocean.Manager(token=account.token)

def print_all():
    for droplet in manager.get_all_droplets():
        print droplet, droplet.ip_address, droplet.id, droplet.tags

if __name__ == "__main__":
    print_all()
