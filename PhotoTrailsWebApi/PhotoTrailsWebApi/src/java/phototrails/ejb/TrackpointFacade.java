/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package phototrails.ejb;

import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import phototrails.entity.Trackpoint;

/**
 *
 * @author ealesec
 */
@Stateless
public class TrackpointFacade extends AbstractFacade<Trackpoint> implements TrackpointFacadeLocal {

    @PersistenceContext(unitName = "PhotoTrailsWebApiPU")
    private EntityManager em;

    @Override
    protected EntityManager getEntityManager() {
        return em;
    }

    public TrackpointFacade() {
        super(Trackpoint.class);
    }
    
}
